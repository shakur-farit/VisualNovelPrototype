using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Services;
using Naninovel;
using Zenject;

namespace Code.Gameplay.Quest
{
	public class StartMinigame : Command
	{
		public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
		{
			DiContainer container = ProjectContext.Instance.Container;
			IWindowService windowService = container.Resolve<IWindowService>();
			windowService.Open(WindowId.MinigameWindow);
			return UniTask.CompletedTask;
		}
	}
}