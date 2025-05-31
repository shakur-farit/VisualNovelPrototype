using Naninovel;

namespace Code.Infrastructure.ScenarioSwitching
{
	public class ScenarioSwitcher : IScenarioSwitcher
	{
		private readonly IScriptPlayer _scriptPlayer;
		private bool _isTransitioning;

		public ScenarioSwitcher() => 
			_scriptPlayer = Engine.GetService<IScriptPlayer>();

		public async UniTask SafePlayAsync(string scriptName)
		{
			if (_isTransitioning)
				return;

			string currentScriptName = null;

			if (_scriptPlayer.PlayedScript != null)
				currentScriptName = _scriptPlayer.PlayedScript.Name;

			if (currentScriptName == scriptName)
				return;

			_isTransitioning = true;

			_scriptPlayer.Stop();
			await UniTask.Yield();

			await _scriptPlayer.PreloadAndPlayAsync(scriptName);

			_isTransitioning = false;
		}
	}
}