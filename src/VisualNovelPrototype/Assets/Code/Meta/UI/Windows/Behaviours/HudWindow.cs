using Code.Gameplay.Quest;
using Code.Meta.UI.Windows.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Windows.Behaviours
{
	public class HudWindow : BaseWindow
	{
		[SerializeField] private Button _questButton;
		[SerializeField] private Button _settingsButton;
		[SerializeField] private Button _mapButton;

		private IWindowService _windowService;
		private ISoundEffectFactory _soundEffectFactory;

		[Inject]
		public void Constructor(IWindowService windowService, ISoundEffectFactory soundEffectFactory)
		{
			Id = WindowId.Hud;

			_windowService = windowService;
			_soundEffectFactory = soundEffectFactory;
		}

		protected override void Initialize()
		{
			_questButton.onClick.AddListener(OpenQuestWindow);
			_settingsButton.onClick.AddListener(OpenSettingsWindow);
			_mapButton.onClick.AddListener(OpenMapWindow);
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
	}
}