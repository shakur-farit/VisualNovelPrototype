using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Services;
using Naninovel;
using Zenject;

namespace Code.Gameplay.Hud.Commands
{
	public class HideHud : Command
	{
		public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
		{
			DiContainer container = ProjectContext.Instance.Container;
			IWindowService windowService = container.Resolve<IWindowService>();
			windowService.Close(WindowId.Hud);
			return UniTask.CompletedTask;
		}
	}
}