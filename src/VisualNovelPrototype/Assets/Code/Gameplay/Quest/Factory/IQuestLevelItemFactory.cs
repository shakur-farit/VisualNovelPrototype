using Code.Gameplay.Quest.Behaviours;
using Code.Gameplay.Quest.Configs;
using UnityEngine;

namespace Code.Gameplay.Quest.Factory
{
	public interface IQuestLevelItemFactory
	{
		QuestLevelItem CreateQuestLevelItem(QuestLevel level, Transform parent);
	}
}