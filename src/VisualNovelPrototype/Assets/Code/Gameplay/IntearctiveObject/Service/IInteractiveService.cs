using Cysharp.Threading.Tasks;

namespace Code.Gameplay.IntearctiveObject.Commands
{
	public interface IInteractiveService
	{
		UniTask ShowInteractiveButtons();
	}
}