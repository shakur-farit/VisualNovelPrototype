using Code.Audio.SoundEffects;
using Code.Audio.SoundEffects.Factory;
using Code.Gameplay.Quest.Behaviours;
using Code.Gameplay.Quest.Service;
using Code.Meta.UI.Windows.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Windows.Behaviours
{
	public class HudWindow : BaseWindow
	{
		private const string QuestWasCompleted = "Quest was completed";
		private const string QuestWasUpdated = "Quest was updated";

		[SerializeField] private Button _questButton;
		[SerializeField] private Button _settingsButton;
		[SerializeField] private Button _mapButton;
		[SerializeField] private QuestNotification _questNotification;

		private IWindowService _windowService;
		private ISoundEffectFactory _soundEffectFactory;
		private IQuestUpdater _questUpdater;

		[Inject]
		public void Constructor(
			IWindowService windowService, 
			ISoundEffectFactory soundEffectFactory,
			IQuestUpdater questUpdater)
		{
			Id = WindowId.Hud;

			_windowService = windowService;
			_soundEffectFactory = soundEffectFactory;
			_questUpdater = questUpdater;
		}

		protected override void Initialize()
		{
			_questButton.onClick.AddListener(OpenQuestWindow);
			_settingsButton.onClick.AddListener(OpenSettingsWindow);
			_mapButton.onClick.AddListener(OpenMapWindow);
		}

		protected override void SubscribeUpdates()
		{
			_questUpdater.OnQuestCompleted += UpdateQuestNotificationTextOnQuestCompleted;
			_questUpdater.OnQuestUpdated += UpdateQuestNotificationTextOnQuestUpdated;
		}

		protected override void UnsubscribeUpdates()
		{
			_questUpdater.OnQuestCompleted -= UpdateQuestNotificationTextOnQuestCompleted;
			_questUpdater.OnQuestUpdated -= UpdateQuestNotificationTextOnQuestUpdated;
		}

		private void OpenQuestWindow()
		{
			_windowService.Open(WindowId.QuestWindow);
			_soundEffectFactory.CreateSoundEffect(SoundEffectTypeId.Click);
		}

		private void OpenSettingsWindow()
		{
			_windowService.Open(WindowId.SettingsWindow);
			_soundEffectFactory.CreateSoundEffect(SoundEffectTypeId.Click);
		}

		private void OpenMapWindow()
		{
			_windowService.Open(WindowId.MapWindow);
			_soundEffectFactory.CreateSoundEffect(SoundEffectTypeId.Click);
		}

		private void UpdateQuestNotificationTextOnQuestCompleted() => 
			_questNotification.ShowNotification(QuestWasCompleted);

		private void UpdateQuestNotificationTextOnQuestUpdated() => 
			_questNotification.ShowNotification(QuestWasUpdated);
	}
}