using Code.Infrastructure.States.StateInfrastructure;
using Naninovel;

namespace Code.Infrastructure.States.GameStates
{
	public class GameplayState : IState
	{
		public async void Enter()
		{
			await InitNaninovel();

			var scriptPlayer = Engine.GetService<IScriptPlayer>();

			 scriptPlayer.PreloadAndPlayAsync("FirstLocation");
		}

		public void Exit()
		{
		}

		private async UniTask InitNaninovel() =>
			await RuntimeInitializer.InitializeAsync();

	}
}