using Code.Meta.UI.Windows.Services;
using Naninovel;
using Zenject;

namespace Code.Meta.UI.Commands
{
	public class DeactivateMapPoints : Command
	{
		public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
		{
			DiContainer container = ProjectContext.Instance.Container;
			IMapPointActivator activator = container.Resolve<IMapPointActivator>();
			activator.DeactiveFirstLocation();
			activator.DeactiveSecondLocation();
			return UniTask.CompletedTask;
		}
	}
}