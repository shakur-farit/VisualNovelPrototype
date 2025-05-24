using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Gameplay.Quest
{
	public interface IMinigameService
	{
		UniTask StartGame();
		void SelectCard(CardItem item);
		void SetCardsHolder(Transform cardsHolder);
	}
}