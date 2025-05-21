using UnityEngine;

namespace Code.Meta.UI.Windows.Configs
{
	[CreateAssetMenu(menuName = "Novel/Window Config", fileName = "WindowConfig")]
	public class WindowConfig : ScriptableObject
	{
		public WindowId TypeId;
		public GameObject ViewPrefab;
	}
}