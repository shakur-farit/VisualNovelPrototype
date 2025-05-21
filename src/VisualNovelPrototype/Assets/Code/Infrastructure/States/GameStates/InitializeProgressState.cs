using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Progress.Data;
using Code.Progress.Provider;

namespace Code.Infrastructure.States.GameStates
{
	public class InitializeProgressState : IState
	{
		private readonly IGameStateMachine _gameStateMachine;
		private readonly IProgressProvider _progressProvider;

		public InitializeProgressState(IGameStateMachine gameStateMachine, IProgressProvider progressProvider)
		{
			_gameStateMachine = gameStateMachine;
			_progressProvider = progressProvider;
		}

		public void Enter()
		{
			CreateNewProgress();
			EnterToLoadStaticDataState();
		}

		private void EnterToLoadStaticDataState() => 
			_gameStateMachine.Enter<LoadStaticDataState>();

		public void Exit()
		{
		}

		private void CreateNewProgress() =>
			_progressProvider.SetProgressData(new ProgressData());
	}
}