using UnityEngine;

namespace Code.Gameplay.Quest
{
	[CreateAssetMenu(menuName = "Novel/Sound Effect Config", fileName = "SoundEffectConfig")]
	public class SoundEffectConfig : ScriptableObject
	{
		public SoundEffectTypeId TypeId;
		public AudioClip AudioClip;
		public GameObject ViewPrefab;
	}
}