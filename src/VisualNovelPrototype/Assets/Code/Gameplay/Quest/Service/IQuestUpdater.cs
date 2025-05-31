using System;

namespace Code.Gameplay.Quest.Service
{
	public interface IQuestUpdater
	{
		void UpdateQuest(QuestTypeId id);
		event Action OnQuestCompleted;
		event Action OnQuestUpdated;
	}
}