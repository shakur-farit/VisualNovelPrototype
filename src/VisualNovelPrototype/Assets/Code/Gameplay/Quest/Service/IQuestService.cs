using System.Collections.Generic;

namespace Code.Meta.UI.Windows
{
	public interface IQuestService
	{
		void AddQuest(QuestTypeId id);
		void MarkQuestComplete(QuestTypeId id);
		void RemoveQuest(QuestTypeId id);
		Dictionary<QuestTypeId, QuestStatus> Quests { get; }
	}
}