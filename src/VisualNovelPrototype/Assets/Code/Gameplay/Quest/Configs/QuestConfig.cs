using UnityEngine;

namespace Code.Meta.UI.Windows
{
	[CreateAssetMenu(menuName = "Novel/Quest Config", fileName = "QuestConfig")]
	public class QuestConfig : ScriptableObject
	{
		public QuestTypeId Id;
		public QuestStatus Status;
		public string Title;
		public string Description;
		public GameObject PrefabView;
	}
}