using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;

namespace Code.Infrastructure.States.GameStates
{
	public class InitializeProgressState : IState
	{
		private readonly IGameStateMachine _gameStateMachine;

		public InitializeProgressState(IGameStateMachine gameStateMachine) => 
			_gameStateMachine = gameStateMachine;

		public void Enter()
		{
			EnterToLoadStaticDataState();
		}

		private void EnterToLoadStaticDataState() => 
			_gameStateMachine.Enter<LoadStaticDataState>();

		public void Exit()
		{
		}
	}
}