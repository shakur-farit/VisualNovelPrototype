using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Quest.Behaviours;
using Code.Gameplay.Quest.Configs;
using Code.Gameplay.Quest.Factory;
using Code.Infrastructure.StaticData;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Gameplay.Quest.Service
{
	public class QuestService : IQuestUpdater, IQuestShower, IQuestDescriptionUpdater
	{
		public event Action<string> OnActiveLevelSelected;

		private readonly Dictionary<QuestTypeId, List<QuestLevel>> _quests = new();
		private readonly List<QuestLevelItem> _questLevelItems = new();

		private Transform _questItemHolder;
		private Transform _questLevelItemHolder;

		private readonly IStaticDataService _staticDataService;
		private readonly IQuestItemFactory _questItemFactory;
		private readonly IQuestLevelItemFactory _questLevelItemFactory;

		public Dictionary<QuestTypeId, List<QuestLevel>> Quests => _quests;

		public QuestService(
			IStaticDataService staticDataService,
			IQuestItemFactory questItemFactory,
			IQuestLevelItemFactory questLevelItemFactory)
		{
			_staticDataService = staticDataService;
			_questItemFactory = questItemFactory;
			_questLevelItemFactory = questLevelItemFactory;
		}

		public void UpdateQuest(QuestTypeId id)
		{
			if (_quests.ContainsKey(id) == false)
			{
				AddQuest(id);
			}

			QuestLevel current = GetActiveLevel(id);
			if (current != null)
				current.levelStatus = QuestLevelStatus.Completed;

			QuestLevel next = GetNextUnactiveLevel(id);
			if (next != null)
			{
				next.levelStatus = QuestLevelStatus.Active;
				return;
			}

			CompleteQuest(id);
		}

		public void ShowQuests()
		{
			foreach (QuestTypeId id in _quests.Keys) 
				_questItemFactory.CreateQuestItem(id, _questItemHolder);
		}

		public void ShowQuestLevels(QuestTypeId id)
		{
			ClearQuestLevelsList();

			if (_quests.TryGetValue(id, out List<QuestLevel> levels) == false)
				return;

			List<QuestLevel> shownLevels = levels
				.Where(l => l.levelStatus is QuestLevelStatus.Active or QuestLevelStatus.Completed)
				.ToList();

			_questLevelItems.AddRange(
				shownLevels
					.Select(l => _questLevelItemFactory.CreateQuestLevelItem(l, _questLevelItemHolder)));

			QuestLevel activeLevel = shownLevels.FirstOrDefault(l => l.levelStatus == QuestLevelStatus.Active);
			if (activeLevel != null)
				InvokeOnSelected(activeLevel.Description);
		}

		public void SetHolders(Transform questItemsHolder, Transform questLevelItemsHolder)
		{
			_questItemHolder = questItemsHolder;
			_questLevelItemHolder = questLevelItemsHolder;
		}

		private void AddQuest(QuestTypeId id)
		{
			if(_quests.ContainsKey(id))
				return;

			List<QuestLevel> levels = GetConfig(id).Levels
				.Select(l => l.Clone())
				.ToList();

			_quests.Add(id, levels);
		}

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

		private QuestConfig GetConfig(QuestTypeId id) => 
			_staticDataService.GetQuestConfig(id);

		public void ClearQuestLevelsList()
		{
			foreach (QuestLevelItem item in _questLevelItems)
				if (item != null)
					Object.Destroy(item.gameObject);

			_questLevelItems.Clear();
		}

		private void InvokeOnSelected(string description) => 
			OnActiveLevelSelected?.Invoke(description);
	}
}