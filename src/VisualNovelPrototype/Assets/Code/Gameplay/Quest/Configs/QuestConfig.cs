using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

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
		[FormerlySerializedAs("Status")] public QuestLevelStatus levelStatus;
		public string Title;
		public string Description;
		public GameObject PrefabView;
	}
}