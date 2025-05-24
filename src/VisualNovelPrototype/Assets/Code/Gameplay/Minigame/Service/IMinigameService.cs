using Code.Gameplay.Minigame.Behaviours;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Gameplay.Minigame.Service
{
	public interface IMinigameService
	{
		UniTask StartGame();
		void SelectCard(CardItem item);
		void SetCardsHolder(Transform cardsHolder);
	}
}