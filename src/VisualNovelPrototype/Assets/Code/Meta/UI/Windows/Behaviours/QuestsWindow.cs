using System.Collections.Generic;
using Code.Gameplay.Quest;
using Code.Gameplay.Quest.Behaviours;
using Code.Gameplay.Quest.Factory;
using Code.Gameplay.Quest.Service;
using Code.Meta.UI.Windows.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Windows.Behaviours
{
	public class QuestsWindow : BaseWindow
	{
		[SerializeField] private Transform _questItemsHolder;
		[SerializeField] private Transform _questLevelItemsHolder;
		[SerializeField] private TextMeshProUGUI _questDescriptionText;
		[SerializeField] private Button _closeButton;

		private readonly List<QuestItem> _questItems = new();

		private IQuestService _questService;
		private IQuestItemFactory _questItemFactory;
		private IWindowService _windowService;

		[Inject]
		public void Constructor(
			IQuestService questService, 
			IQuestItemFactory questItemFactory,
			IWindowService windowService)
		{
			Id = WindowId.QuestWindow;

			_questService = questService;
			_questItemFactory = questItemFactory;
			_windowService = windowService;
		}

		protected override void Initialize()
		{
			_closeButton.onClick.AddListener(CloseWindow);
			
			CreateQuestItems();
		}

		private void CreateQuestItems()
		{
			ClearItemsHolder();

			foreach (QuestTypeId questTypeId in _questService.Quests.Keys)
			{
				QuestItem item = 
					_questItemFactory
						.CreateQuestItem(
							questTypeId,
							_questItemsHolder, 
							UpdateDescriptionText, 
							_questService.Quests[questTypeId], 
							_questLevelItemsHolder);
				_questItems.Add(item);
			}
		}

		private void ClearItemsHolder()
		{
			foreach (QuestItem questItem in _questItems) 
				Destroy(questItem.gameObject);
			
			_questItems.Clear();
		}

		private void UpdateDescriptionText(string text) => 
			_questDescriptionText.text = text;

		private void CloseWindow() => 
			_windowService.Close(WindowId.QuestWindow);
	}
}