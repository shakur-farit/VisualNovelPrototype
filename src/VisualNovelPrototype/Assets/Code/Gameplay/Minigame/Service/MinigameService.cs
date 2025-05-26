using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Minigame.Behaviours;
using Code.Gameplay.Minigame.Factory;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Minigame.Service
{
	public class MinigameService : IMinigameService
	{
		private const int CardsInGame = 8;
		private const int MatchGroupSize = 2;

		private readonly CardTypeId[] _availableCardTypes =
			((CardTypeId[])System.Enum.GetValues(typeof(CardTypeId)))
			.Where(id => id != CardTypeId.Unknown)
			.ToArray();

		private Transform _cardsHolder;

		private readonly List<CardItem> _cards = new();
		private readonly List<CardItem> _selectedCards = new();

		private UniTaskCompletionSource _gameFinishedTcs;

		private readonly ICardFactory _cardFactory;
		private readonly IWindowService _windowService;


		public MinigameService(ICardFactory cardFactory, IWindowService windowService)
		{
			_cardFactory = cardFactory;
			_windowService = windowService;
		}

		public void SetCardsHolder(Transform cardsHolder) =>
			_cardsHolder = cardsHolder;

		public UniTask StartGame()
		{
			_gameFinishedTcs = new UniTaskCompletionSource();

			ClearCards();
			ClearSelectedCards();
			CreateCards();

			return _gameFinishedTcs.Task;
		}

		public async void SelectCard(CardItem item, Image selectedIcon)
		{
			if (_selectedCards.Contains(item))
				return;

			_selectedCards.Add(item);
			
			if(_selectedCards.Count > MatchGroupSize)
				return;
			
			selectedIcon.enabled = true;

			if (_selectedCards.Count == MatchGroupSize)
			{
				ShowSelectedCards();

				await CheckCards();

				ClearSelectedCards();
			}
		}

		private void CreateCards()
		{
			for (int i = 0; i < CardsInGame; i++)
			{
				CardTypeId randomCard = _availableCardTypes[Random.Range(0, _availableCardTypes.Length)];
				CardItem item = _cardFactory.CreateCardItem(randomCard, _cardsHolder);
				_cards.Add(item);
			}
		}

		private void ShowSelectedCards()
		{
			foreach (CardItem selectedCard in _selectedCards)
				selectedCard.ShowCard();
		}

		private async UniTask CheckCards()
		{
			if (IsAllSelectedCardSame())
			{
				CheckRemainingCards();

				return;
			}

			await UniTask.Delay(1000);

			foreach (CardItem card in _selectedCards)
				card.HideCard();
		}

		private async void CheckRemainingCards()
		{
			foreach (CardItem card in _selectedCards)
				_cards.Remove(card);

			if (HasPossibleMatch() == false)
			{
				await UniTask.Delay(1000);

				EndGame();
			}
		}

		private void EndGame()
		{
			_windowService.Close(WindowId.MinigameWindow);

			_gameFinishedTcs?.TrySetResult();
		}

		private bool IsAllSelectedCardSame() =>
			_selectedCards
				.Select(c => c.Id)
				.Distinct()
				.Count() == 1;

		private bool HasPossibleMatch() =>
			_cards
				.GroupBy(card => card.Id)
				.Any(g => g.Count() >= MatchGroupSize);

		private void ClearCards() =>
			_cards.Clear();

		private void ClearSelectedCards() =>
			_selectedCards.Clear();
	}
}