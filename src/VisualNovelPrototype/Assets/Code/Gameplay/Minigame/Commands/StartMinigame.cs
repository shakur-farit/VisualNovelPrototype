using System.Threading.Tasks;
using Code.Meta.UI.Windows.Services;
using Code.Meta.UI.Windows;
using Naninovel;
using Zenject;

namespace Code.Gameplay.Quest
{
	public class StartMinigame : Command
	{
		public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
		{
			OpenWindow();
			await StartGame();
		}

		public UniTask OpenWindow()
		{
			DiContainer container = ProjectContext.Instance.Container;
			IWindowService windowService = container.Resolve<IWindowService>();
			windowService.Open(WindowId.MinigameWindow);
			return UniTask.CompletedTask;
		}

		public async UniTask StartGame()
		{
			DiContainer container = ProjectContext.Instance.Container;
			IMinigameService minigameService = container.Resolve<IMinigameService>();
			await minigameService.StartGame();
		}
	}
}