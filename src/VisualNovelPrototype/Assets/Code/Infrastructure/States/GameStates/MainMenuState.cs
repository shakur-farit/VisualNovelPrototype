using Code.Infrastructure.States.StateInfrastructure;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Services;
using Naninovel;

namespace Code.Infrastructure.States.GameStates
{
	public class MainMenuState : IState
	{
		private readonly IWindowService _windowService;

		public MainMenuState(IWindowService windowService) => 
			_windowService = windowService;

		public void Enter() => 
			OpenMainMenuWindow();

		public void Exit()
		{

		}

		private void OpenMainMenuWindow() => 
			_windowService.Open(WindowId.MainMenuWindow);
	}
}