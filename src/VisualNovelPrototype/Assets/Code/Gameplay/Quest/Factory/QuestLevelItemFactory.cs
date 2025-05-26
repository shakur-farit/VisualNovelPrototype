using Code.Gameplay.Quest.Behaviours;
using Code.Gameplay.Quest.Configs;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Quest.Factory
{
	public class QuestLevelItemFactory : IQuestLevelItemFactory
	{
		private readonly IInstantiator _instantiator;

		public QuestLevelItemFactory(IInstantiator instantiator) => 
			_instantiator = instantiator;

		public QuestLevelItem CreateQuestLevelItem(QuestLevel level, Transform parent)
		{

			QuestLevelItem item = _instantiator.InstantiatePrefabForComponent<QuestLevelItem>(level.PrefabView, parent);
			item.Setup(level.Title, level.levelStatus);
			return item;
		}
	}
}