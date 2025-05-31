using UnityEngine;

namespace Code.Gameplay.IntearctiveObject.Configs
{
	[CreateAssetMenu(menuName = "Novel/Interactive Object Config", fileName = "InteractiveObjectConfig")]
	public class InteractiveObjectConfig : ScriptableObject
	{
		public InteractiveObjectTypeId TypeId;
		public GameObject ViewPrefab;
	}
}