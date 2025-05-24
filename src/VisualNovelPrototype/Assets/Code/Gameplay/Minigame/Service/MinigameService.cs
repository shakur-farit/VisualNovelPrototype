using System.Collections.Generic;
using System.Linq;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Gameplay.Quest
{
	public class MinigameService : IMinigameService
	{
		private const int CardsInGame = 8;
		private const int MatchGroupSize = 2;

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

		public void SetCardsHolder(Transform cardsHolder)
		{
			_cardsHolder = cardsHolder;

			Debug.Log(_cardsHolder);
		}

		public UniTask StartGame()
		{
			_gameFinishedTcs = new UniTaskCompletionSource();

			_cards.Clear();
			_selectedCards.Clear();

			Debug.Log(_cardsHolder);


			for (int i = 0; i < CardsInGame; i++)
			{
				CardTypeId randomCard = (CardTypeId)Random.Range(1, 5);
				CardItem item = _cardFactory.CreateCardItem(randomCard, _cardsHolder);
				_cards.Add(item);
			}

			return _gameFinishedTcs.Task;
		}

		public async void SelectCard(CardItem item)
		{
			if (_selectedCards.Contains(item))
				return;

			_selectedCards.Add(item);

			if (_selectedCards.Count >= MatchGroupSize)
			{
				ShowSelectedCards();

				await CheckCards();

				ClearSelectedCards();
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

		private void ClearSelectedCards() =>
			_selectedCards.Clear();
	}
}