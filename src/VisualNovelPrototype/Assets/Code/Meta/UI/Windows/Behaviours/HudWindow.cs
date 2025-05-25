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

		[Inject]
		public void Constructor(IWindowService windowService)
		{
			Id = WindowId.Hud;

			_windowService = windowService;
		}

		protected override void Initialize()
		{
			_questButton.onClick.AddListener(OpenQuestWindow);
			_settingsButton.onClick.AddListener(OpenSettingsWindow);
			_mapButton.onClick.AddListener(OpenMapWindow);
		}

		private void OpenQuestWindow() =>
			_windowService.Open(WindowId.QuestWindow);

		private void OpenSettingsWindow() => 
			_windowService.Open(WindowId.SettingsWindow);

		private void OpenMapWindow() => 
			_windowService.Open(WindowId.MapWindow);
	}
}