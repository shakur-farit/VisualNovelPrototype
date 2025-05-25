using Code.Meta.UI.Windows.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Windows.Behaviours
{
	public class SettingsWindow : BaseWindow
	{
		[SerializeField] private Button _closeButton;
		[SerializeField] private Button _quitGameButton;

		private IWindowService _windowService;

		[Inject]
		public void Constructor(IWindowService windowService)
		{
			Id = WindowId.SettingsWindow;

			_windowService = windowService;
		}

		protected override void Initialize()
		{
			_closeButton.onClick.AddListener(CloseWindow);
			_quitGameButton.onClick.AddListener(QuitGame);
		}

		private void CloseWindow() =>
			_windowService.Close(WindowId.SettingsWindow);

		private void QuitGame()
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
		}
	}
}