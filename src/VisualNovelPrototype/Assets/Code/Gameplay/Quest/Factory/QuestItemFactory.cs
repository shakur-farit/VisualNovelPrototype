using Code.Gameplay.Quest.Behaviours;
using Code.Gameplay.Quest.Configs;
using Code.Infrastructure.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Quest.Factory
{
	public class QuestItemFactory : IQuestItemFactory
	{
		private readonly IStaticDataService _staticDataService;
		private readonly IInstantiator _instantiator;

		public QuestItemFactory(IStaticDataService staticDataService, IInstantiator instantiator)
		{
			_staticDataService = staticDataService;
			_instantiator = instantiator;
		}

		public QuestItem CreateQuestItem(QuestTypeId id, Transform parent)
		{
			QuestConfig config = _staticDataService.GetQuestConfig(id);

			QuestItem item = _instantiator.InstantiatePrefabForComponent<QuestItem>(config.PrefabView, parent);
			item.Setup(config);
			return item;
		}
	}
}