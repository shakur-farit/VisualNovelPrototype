using System.Collections.Generic;
using System.Linq;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Gameplay.Quest
{
	public class MinigameService : IMinigameService
	{
		private const int CardsInGame = 8;
		private const int MatchGroupSize = 2;

		private readonly List<CardItem> _cards = new();
		private readonly List<CardItem> _selectedCards = new();

		private readonly ICardFactory _cardFactory;
		private readonly IWindowService _windowService;


		public MinigameService(ICardFactory cardFactory, IWindowService windowService)
		{
			_cardFactory = cardFactory;
			_windowService = windowService;
		}

		public void StartGame(Transform cardParent)
		{
			for (int i = 0; i < CardsInGame; i++)
			{
				CardTypeId randomCard = (CardTypeId)Random.Range(1, 5);
				CardItem item = _cardFactory.CreateCardItem(randomCard, cardParent);
				_cards.Add(item);
			}
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

		public void ShowSelectedCards()
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

		private void CheckRemainingCards()
		{
			foreach (CardItem card in _selectedCards) 
				_cards.Remove(card);

			if (HasPossibleMatch() == false)
				EndGame();
		}

		private void EndGame()
		{
			Debug.Log("endGame");
			_windowService.Close(WindowId.MinigameWindow);
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