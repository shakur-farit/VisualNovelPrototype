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

		private IQuestShower _questShower;
		private IWindowService _windowService;
		private IQuestDescriptionUpdater _descriptionUpdater;

		[Inject]
		public void Constructor(
			IQuestShower questShower,
			IQuestDescriptionUpdater descriptionUpdater,
			IWindowService windowService)
		{
			Id = WindowId.QuestWindow;

			_questShower = questShower;
			_descriptionUpdater = descriptionUpdater;
			_windowService = windowService;
		}

		protected override void Initialize()
		{
			_closeButton.onClick.AddListener(CloseWindow);
			_descriptionUpdater.OnActiveLevelSelected += UpdateDescriptionText;

			SetHolders();
			ShowQuestItems();
		}

		protected override void UnsubscribeUpdates() => 
			_descriptionUpdater.OnActiveLevelSelected -= UpdateDescriptionText;

		private void SetHolders() => 
			_questShower.SetHolders(_questItemsHolder, _questLevelItemsHolder);

		private void ShowQuestItems() => 
			_questShower.ShowQuests();


		private void UpdateDescriptionText(string text) => 
			_questDescriptionText.text = text;

		private void CloseWindow()
		{
			_questShower.ResetShowedQuest();
			_windowService.Close(WindowId.QuestWindow);
		}
	}
}