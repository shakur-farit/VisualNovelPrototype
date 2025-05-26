using Code.Gameplay.Minigame.Behaviours;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Minigame.Service
{
	public interface IMinigameService
	{
		UniTask StartGame();
		void SelectCard(CardItem item, Image selectedIcon);
		void SetCardsHolder(Transform cardsHolder);
	}
}