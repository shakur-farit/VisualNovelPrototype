using System.Collections.Generic;

namespace Code.Gameplay.Quest.Service
{
	public interface IQuestService
	{
		void AddQuest(QuestTypeId id);
		void MarkQuestComplete(QuestTypeId id);
		void RemoveQuest(QuestTypeId id);
		Dictionary<QuestTypeId, QuestStatus> Quests { get; }
	}
}