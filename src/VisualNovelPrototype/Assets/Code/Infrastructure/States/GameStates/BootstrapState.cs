using Code.Infrastructure.AssetsManagement;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.States.GameStates
{
	public class BootstrapState : IState
	{
		private readonly IGameStateMachine _stateMachine;
		private readonly IAssetProvider _assetProvider;

		public BootstrapState(IGameStateMachine stateMachine, IAssetProvider assetProvider)
		{
			_stateMachine = stateMachine;
			_assetProvider = assetProvider;
		}

		public async void Enter()
		{
			await InitAddressables();
			EnterToInitializeProgressState();
		}

		public void Exit()
		{

		}

		private async UniTask InitAddressables() =>
			await _assetProvider.Initialize();

		private void EnterToInitializeProgressState() =>
			_stateMachine.Enter<InitializeProgressState>();
	}
}