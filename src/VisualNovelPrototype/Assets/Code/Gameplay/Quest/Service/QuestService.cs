using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Quest.Configs;
using Code.Infrastructure.StaticData;

namespace Code.Gameplay.Quest.Service
{
	public class QuestService : IQuestService
	{
		private readonly Dictionary<QuestTypeId, List<QuestLevel>> _quests = new();

		private readonly IStaticDataService _staticDataService;

		public Dictionary<QuestTypeId, List<QuestLevel>> Quests => _quests;

		public QuestService(IStaticDataService staticDataService) => 
			_staticDataService = staticDataService;

		public void AddQuest(QuestTypeId id)
		{
			if(_quests.ContainsKey(id))
				return;

			_quests.Add(id, GetConfig(id).Levels);
		}

		public void UpdateQuest(QuestTypeId id)
		{
			if (_quests.ContainsKey(id) == false)
				return;

			var current = GetActiveLevel(id);
			if (current != null)
				current.levelStatus = QuestLevelStatus.Completed;

			var next = GetNextUnactiveLevel(id);
			if (next != null)
			{
				next.levelStatus = QuestLevelStatus.Active;
				return;
			}

			CompleteQuest(id);
		}

		private QuestConfig GetConfig(QuestTypeId id) => 
			_staticDataService.GetQuestConfig(id);

		private QuestLevel GetActiveLevel(QuestTypeId id)
		{
			if (_quests.TryGetValue(id, out var levels))
				return levels.FirstOrDefault(l => l.levelStatus == QuestLevelStatus.Active);

			return null;
		}

		private QuestLevel GetNextUnactiveLevel(QuestTypeId id)
		{
			if (_quests.TryGetValue(id, out var levels))
				return levels.FirstOrDefault(l => l.levelStatus == QuestLevelStatus.Unactive);

			return null;
		}

		private void CompleteQuest(QuestTypeId id) => 
			_quests.Remove(id);
	}
}