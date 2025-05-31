using Naninovel;

namespace Code.Infrastructure.ScenarioSwitching
{
	public interface IScenarioSwitcher
	{
		UniTask SafePlayAsync(string scriptName);
	}
}