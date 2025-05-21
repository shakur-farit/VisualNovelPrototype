using Code.Infrastructure.States.StateInfrastructure;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Services;

namespace Code.Infrastructure.States.GameStates
{
	public class MainMenuState : IState
	{
		private readonly IWindowService _windowService;

		public MainMenuState(IWindowService windowService)
		{
			_windowService = windowService;
		}

		public void Enter()
		{
			_windowService.Open(WindowId.MainMenuWindow);
		}

		public void Exit()
		{

		}
	}
}