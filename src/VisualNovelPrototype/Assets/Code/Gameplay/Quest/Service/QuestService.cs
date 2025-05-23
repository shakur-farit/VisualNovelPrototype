using System.Collections.Generic;

namespace Code.Gameplay.Quest.Service
{
	public class QuestService : IQuestService
	{
		private readonly Dictionary<QuestTypeId, QuestStatus> _quests = new();

		public Dictionary<QuestTypeId, QuestStatus> Quests => _quests;

		public void AddQuest(QuestTypeId id) => 
			_quests.Add(id, QuestStatus.Active);

		public void MarkQuestComplete(QuestTypeId id)
		{
			if (_quests.ContainsKey(id))
				_quests[id] = QuestStatus.Completed;
		}

		public void RemoveQuest(QuestTypeId id)
		{
			if (_quests.ContainsKey(id))
				_quests.Remove(id);
		}
	}
}