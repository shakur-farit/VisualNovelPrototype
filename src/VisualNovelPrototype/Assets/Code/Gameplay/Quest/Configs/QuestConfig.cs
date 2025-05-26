using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Quest.Configs
{
	[CreateAssetMenu(menuName = "Novel/Quest Config", fileName = "QuestConfig")]
	public class QuestConfig : ScriptableObject
	{
		public QuestTypeId Id;
		public QuestStatus Status;
		public string QuestName;
		public GameObject PrefabView;
		public List<QuestLevel> Levels;
	}

	[Serializable]
	public class QuestLevel
	{
		public string Title;
		public string Description;
	}
}