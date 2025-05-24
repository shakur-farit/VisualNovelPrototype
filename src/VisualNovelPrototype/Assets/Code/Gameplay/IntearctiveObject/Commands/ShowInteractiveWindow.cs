using Naninovel;
using Zenject;

namespace Code.Gameplay.IntearctiveObject.Commands
{
	public class ShowInteractiveButtons : Command
	{
		public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
		{
			DiContainer container = ProjectContext.Instance.Container;
			IInteractiveService interactiveService = container.Resolve<IInteractiveService>();
			interactiveService.ShowInteractiveButtons();
			return UniTask.CompletedTask;
		}
	}
}