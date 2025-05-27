using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Quest.Configs
{
	[CreateAssetMenu(menuName = "Novel/Quest Config", fileName = "QuestConfig")]
	public class QuestConfig : ScriptableObject
	{
		public QuestTypeId Id;
		public GameObject PrefabView;
		public List<QuestLevel> Levels;
	}

	[Serializable]
	public class QuestLevel
	{
		public QuestLevelStatus levelStatus;
		public string Title;
		public string Description;
		public GameObject PrefabView;

		public QuestLevel Clone()
		{
			return new QuestLevel
			{
				levelStatus = this.levelStatus,
				Title = this.Title,
				Description = this.Description,
				PrefabView = this.PrefabView
			};
		}
	}
}