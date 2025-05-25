using Code.Meta.UI.Windows.Services;
using Naninovel;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Windows.Behaviours
{
	public class MapWindow : BaseWindow
	{
		private const string Bar = "Bar";
		private const string Street = "Street";

		[SerializeField] private Button _firstLocationButton;
		[SerializeField] private Button _secondLocationButton;
		[SerializeField] private Button _closeButton;

		private IScriptPlayer _scriptPlayer;

		private IWindowService _windowService;
		private IMapPointActivator _activator;
		private IScenarioSwitcher _scenarioSwitcher;


		[Inject]
		public void Constructor(IWindowService windowService, IMapPointActivator activator, IScenarioSwitcher scenarioSwitcher)
		{
			Id = WindowId.MapWindow;

			_windowService = windowService;
			_activator = activator;
			_scenarioSwitcher = scenarioSwitcher;
		}

		protected override void Initialize()
		{
			_firstLocationButton.interactable = _activator.IsFirstLocationActive;
			_secondLocationButton.interactable = _activator.IsSecondLocationActive;

			_scriptPlayer = Engine.GetService<IScriptPlayer>();

			_firstLocationButton.onClick.AddListener(()=>StartScenario(Bar));
			_secondLocationButton.onClick.AddListener(() => StartScenario(Street));
			_closeButton.onClick.AddListener(CloseWindow);
		}

		private async void StartScenario(string scriptName)
		{
			await _scenarioSwitcher.SafePlayAsync(scriptName);
			CloseWindow();
		}

		private void CloseWindow() => 
			_windowService.Close(WindowId.MapWindow);
	}
}