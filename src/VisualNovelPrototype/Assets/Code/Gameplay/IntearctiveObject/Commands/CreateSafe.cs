using Naninovel;
using Zenject;

namespace Code.Gameplay.IntearctiveObject.Commands
{
	public class CreateSafe : Command
	{
		public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
		{
			DiContainer container = ProjectContext.Instance.Container;
			IInteractiveObjectFactory factory = container.Resolve<IInteractiveObjectFactory>();
			InteractiveObjectItem safe = factory.CreateInteractiveObject(InteractiveObjectTypeId.Safe);
			await safe.OpenTask();
		}
	}
}