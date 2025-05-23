using Code.Infrastructure.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Quest
{
	public class CardFactory : ICardFactory
	{
		private readonly IStaticDataService _staticDataService;
		private readonly IInstantiator _instantiator;

		public CardFactory(IStaticDataService staticDataService, IInstantiator instantiator)
		{
			_staticDataService = staticDataService;
			_instantiator = instantiator;
		}

		public CardItem CreateCardItem(CardTypeId id, Transform parent)
		{
			CardConfig config = _staticDataService.GetCardConfig(id);

			var item = _instantiator.InstantiatePrefabForComponent<CardItem>(config.ViewPrefab, parent);
			item.Setup(config);

			return item;
		}
	}
}