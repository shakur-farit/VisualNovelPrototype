using Code.Infrastructure.AssetsManagement;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.StaticData;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.States.GameStates
{
	public class LoadStaticDataState : IState
	{
		private readonly IStaticDataService _staticDataService;
		private readonly IGameStateMachine _stateMachine;

		public LoadStaticDataState(IStaticDataService staticDataService, IGameStateMachine stateMachine)
		{
			_staticDataService = staticDataService;
			_stateMachine = stateMachine;
		}

		public  async void Enter()
		{
			await LoadStaticData();
			EnterToLoadingMainMenuState();
		}

		public void Exit()
		{
		}

		private async UniTask LoadStaticData() =>
			await _staticDataService.Load();

		private void EnterToLoadingMainMenuState() =>
			_stateMachine.Enter<LoadingMainMenuState>();
	}
}