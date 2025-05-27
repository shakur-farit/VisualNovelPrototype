using UnityEngine;

namespace Code.Gameplay.Quest.Service
{
	public interface IQuestShower
	{
		void SetHolders(Transform questItemsHolder, Transform questLevelItemsHolder);
		void ShowQuests();
		void ShowQuestLevels(QuestTypeId id);
	}
}