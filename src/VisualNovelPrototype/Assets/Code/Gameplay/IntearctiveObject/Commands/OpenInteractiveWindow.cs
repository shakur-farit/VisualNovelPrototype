using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Services;
using Naninovel;
using Zenject;

namespace Code.Gameplay.IntearctiveObject.Commands
{
	public class OpenInteractiveWindow : Command
	{
		public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
		{
			DiContainer container = ProjectContext.Instance.Container;
			IWindowService service = container.Resolve<IWindowService>();
			service.Open(WindowId.InteractiveWindow);
			return UniTask.CompletedTask;
		}
	}
}