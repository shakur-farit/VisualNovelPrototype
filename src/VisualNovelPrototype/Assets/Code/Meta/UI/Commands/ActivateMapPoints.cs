using Naninovel;
using Zenject;

namespace Code.Meta.UI.Windows.Services
{
	public class ActivateMapPoints : Command
	{
		public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
		{
			DiContainer container = ProjectContext.Instance.Container;
			IMapPointActivator activator = container.Resolve<IMapPointActivator>();
			activator.ActiveFirstLocation();
			activator.ActiveSecondLocation();
			return UniTask.CompletedTask;
		}
	}
}