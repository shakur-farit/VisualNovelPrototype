using UnityEngine;

namespace Code.Audio.SoundEffects.Configs
{
	[CreateAssetMenu(menuName = "Novel/Sound Effect Config", fileName = "SoundEffectConfig")]
	public class SoundEffectConfig : ScriptableObject
	{
		public SoundEffectTypeId TypeId;
		public AudioClip AudioClip;
		public GameObject ViewPrefab;
	}
}