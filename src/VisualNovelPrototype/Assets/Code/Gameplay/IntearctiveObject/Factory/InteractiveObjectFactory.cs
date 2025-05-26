using Code.Infrastructure.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.IntearctiveObject.Commands
{
	public class InteractiveObjectFactory : IInteractiveObjectFactory
	{
		private Transform _holder;

		private readonly IStaticDataService _staticDataService;
		private readonly IInstantiator _instantiator;

		public InteractiveObjectFactory(IStaticDataService staticDataService, IInstantiator instantiator)
		{
			_staticDataService = staticDataService;
			_instantiator = instantiator;
		}

		public void SetHolder(Transform holder) => 
			_holder = holder;

		public InteractiveObjectItem CreateInteractiveObject(InteractiveObjectTypeId typeId)
		{
			InteractiveObjectConfig config = _staticDataService.GetInteractiveObjectConfig(typeId);

			InteractiveObjectItem interactiveObject = _instantiator.InstantiatePrefabForComponent<InteractiveObjectItem>(config.ViewPrefab, _holder);

			return interactiveObject;
		}
	}
}