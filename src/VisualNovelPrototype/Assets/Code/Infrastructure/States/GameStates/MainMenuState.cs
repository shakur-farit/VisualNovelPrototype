using Code.Infrastructure.AssetsManagement;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;

namespace Code.Infrastructure.States.GameStates
{
	public class MainMenuState : IState
	{
		
		public MainMenuState(IGameStateMachine stateMachine, IAssetProvider assetProvider)
		{
		}

		public void Enter()
		{
		}

		public void Exit()
		{

		}
	}
}