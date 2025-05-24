using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Services;
using Cysharp.Threading.Tasks;

namespace Code.Gameplay.IntearctiveObject.Commands
{
	public class InteractiveService : IInteractiveService
	{
		private UniTaskCompletionSource _doorUsedTsc;

		private readonly IWindowService _windowService;

		public InteractiveService(IWindowService windowService) => 
			_windowService = windowService;

		public UniTask ShowInteractiveButtons()
		{
			_doorUsedTsc = new UniTaskCompletionSource();

			_windowService.Open(WindowId.InteractiveWindow);

			return _doorUsedTsc.Task;
		}
	}
}