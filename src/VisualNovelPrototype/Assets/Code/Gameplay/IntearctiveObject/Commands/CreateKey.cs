using Code.Gameplay.IntearctiveObject.Behaviours;
using Code.Gameplay.IntearctiveObject.Factory;
using Naninovel;
using Zenject;

namespace Code.Gameplay.IntearctiveObject.Commands
{
	public class CreateKey : Command
	{
		public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
		{
			DiContainer container = ProjectContext.Instance.Container;
			IInteractiveObjectFactory factory = container.Resolve<IInteractiveObjectFactory>();
			InteractiveObjectItem key = factory.CreateInteractiveObject(InteractiveObjectTypeId.Key);
			await key.OpenTask();
		}
	}
}