using UnityEngine;

namespace Code.Gameplay.IntearctiveObject.Commands
{
	public interface IInteractiveObjectFactory
	{
		InteractiveObjectItem CreateInteractiveObject(InteractiveObjectTypeId typeId);
		void SetHolder(Transform holder);
	}
}