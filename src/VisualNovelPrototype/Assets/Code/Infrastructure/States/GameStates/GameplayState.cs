using Code.Infrastructure.States.StateInfrastructure;
using Code.Progress.Provider;
using Naninovel;

namespace Code.Infrastructure.States.GameStates
{
	public class GameplayState : IState
	{
		private const string FirstLocation = "FirstLocation";
		private const string PlayerNameKey = "playerName";

		private readonly IProgressProvider _progressProvider;


		public GameplayState(IProgressProvider progressProvider) => 
			_progressProvider = progressProvider;

		public async void Enter()
		{
			await InitNaninovel();
			InitPlayerName();
			await StartScenario();
		}

		public void Exit()
		{
		}

		private async UniTask StartScenario()
		{
			IScriptPlayer scriptPlayer = Engine.GetService<IScriptPlayer>();

			await scriptPlayer.PreloadAndPlayAsync(FirstLocation);
		}

		private void InitPlayerName()
		{
			string playerName = _progressProvider.ProgressData.PlayerData.PlayerName;
			Engine.GetService<ICustomVariableManager>()
				.SetVariableValue(PlayerNameKey, playerName);
		}

		private async UniTask InitNaninovel() =>
			await RuntimeInitializer.InitializeAsync();

	}
}