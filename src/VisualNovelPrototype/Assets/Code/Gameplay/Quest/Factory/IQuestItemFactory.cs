using System;
using System.Collections.Generic;
using Code.Gameplay.Quest.Behaviours;
using Code.Gameplay.Quest.Configs;
using UnityEngine;

namespace Code.Gameplay.Quest.Factory
{
	public interface IQuestItemFactory
	{
		QuestItem CreateQuestItem(QuestTypeId id, Transform questItemsHolder, Action<string> action, List<QuestLevel> levels, Transform levelParent);
	}
}