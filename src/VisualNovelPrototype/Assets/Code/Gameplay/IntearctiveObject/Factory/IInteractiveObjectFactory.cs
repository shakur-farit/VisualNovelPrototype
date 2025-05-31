using Code.Gameplay.IntearctiveObject.Behaviours;
using UnityEngine;

namespace Code.Gameplay.IntearctiveObject.Factory
{
	public interface IInteractiveObjectFactory
	{
		InteractiveObjectItem CreateInteractiveObject(InteractiveObjectTypeId typeId);
		void SetHolder(Transform holder);
	}
}