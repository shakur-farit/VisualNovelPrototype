using System;
using Code.Gameplay.Quest.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Quest.Factory
{
	public interface IQuestItemFactory
	{
		QuestItem CreateQuestItem(QuestTypeId id, Transform questItemsHolder, Action<string> action);
	}
}