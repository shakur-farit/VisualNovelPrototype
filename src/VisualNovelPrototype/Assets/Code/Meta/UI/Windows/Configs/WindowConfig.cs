using UnityEngine;

namespace Code.Infrastructure.AssetsManagement
{
	[CreateAssetMenu(menuName = "Dungeon Gunner/Window Config", fileName = "WindowConfig")]
	public class WindowConfig : ScriptableObject
	{
		public WindowId TypeId;
		public GameObject ViewPrefab;
	}
}