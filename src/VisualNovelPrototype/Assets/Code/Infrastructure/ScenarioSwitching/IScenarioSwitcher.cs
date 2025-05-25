using Naninovel;

namespace Code.Meta.UI.Windows.Services
{
	public interface IScenarioSwitcher
	{
		UniTask SafePlayAsync(string scriptName);
	}
}