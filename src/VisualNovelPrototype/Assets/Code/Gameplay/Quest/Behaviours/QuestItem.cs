using System;
using System.Collections.Generic;
using Code.Gameplay.Quest.Configs;
using Code.Gameplay.Quest.Factory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Quest.Behaviours
{
	public class QuestItem : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _title;
		[SerializeField] private Button _selectButton;

		private bool _levelsInstantiated = false;
		private Action<string> _onSelected;

		private IQuestLevelItemFactory _factory;

		[Inject]
		public void Constructor(IQuestLevelItemFactory factory) => 
			_factory = factory;

		public void Setup(QuestConfig config, Action<string> action, List<QuestLevel> levels, Transform levelParent)
		{
			_title.text = config.Id.ToString();
			_onSelected = action;

			_selectButton.onClick.RemoveAllListeners();
			_selectButton.onClick.AddListener(() => OnClicked(levels, levelParent));
			_selectButton.onClick.AddListener(() => BindEvents(levels));
		}

		private void OnClicked(List<QuestLevel> levels, Transform levelParent)
		{
			if (_levelsInstantiated)
				return;

			foreach (QuestLevel level in levels)
			{
				if (level.levelStatus == QuestLevelStatus.Active ||
				    level.levelStatus == QuestLevelStatus.Completed)
				{
					_factory.CreateQuestLevelItem(level, levelParent);
				}
			}

			_levelsInstantiated = true;
		}

		private void BindEvents(List<QuestLevel> levels)
		{
			foreach (QuestLevel level in levels)
				if (level.levelStatus == QuestLevelStatus.Active)
					_selectButton.onClick.AddListener(() => _onSelected?.Invoke(level.Description));
		}
	}
}