using UnityEngine;

namespace Code.Gameplay.Quest
{
	public interface IMinigameService
	{
		void StartGame(Transform cardParent);
		void SelectCard(CardItem item);
		void ShowSelectedCards();
	}
}