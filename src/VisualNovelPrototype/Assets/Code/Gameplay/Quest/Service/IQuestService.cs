using System.Collections.Generic;
using Code.Gameplay.Quest.Configs;

namespace Code.Gameplay.Quest.Service
{
	public interface IQuestService
	{
		void AddQuest(QuestTypeId id);
		Dictionary<QuestTypeId, List<QuestLevel>> Quests { get; }
		void UpdateQuest(QuestTypeId id);
	}
}