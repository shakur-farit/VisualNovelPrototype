using Code.Meta.UI.Windows.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Windows.Behaviours
{
	public class InvalidNameWindow : BaseWindow
	{
		[SerializeField] private Button _closeButton;

		private IWindowService _windowService;

		[Inject]
		public void Constructor(IWindowService windowService)
		{
			Id = WindowId.InvalidNameWindow;

			_windowService = windowService;
		}

		protected override void Initialize()
		{
			_closeButton.onClick.AddListener(CloseWindow);
		}

		private void CloseWindow() => 
			_windowService.Close(WindowId.InvalidNameWindow);
	}
}