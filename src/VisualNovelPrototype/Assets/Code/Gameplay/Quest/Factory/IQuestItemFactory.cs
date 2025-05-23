using System;
using UnityEngine;

namespace Code.Meta.UI.Windows
{
	public interface IQuestItemFactory
	{
		QuestItem CreateQuestItem(QuestTypeId id, Transform questItemsHolder, Action<string> action);
	}
}