using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;

namespace Code.Infrastructure.States.GameStates
{
	public class LoadingMainMenuState : IState
	{
		private readonly IGameStateMachine _stateMachine;
		private readonly ISceneLoader _sceneLoader;

		public LoadingMainMenuState(IGameStateMachine stateMachine, ISceneLoader sceneLoader)
		{
			_stateMachine = stateMachine;
			_sceneLoader = sceneLoader;
		}

		public void Enter() =>
			LoadMainMenuScene();

		public void Exit()
		{
		}

		private void LoadMainMenuScene() =>
			_sceneLoader.LoadScene(Scenes.MainMenu, EnterHomeScreenState);

		private void EnterHomeScreenState() =>
			_stateMachine.Enter<MainMenuState>();
	}
}