using UnityEngine;

namespace Code.Audio.SoundEffects
{
	public class SoundSfx : MonoBehaviour
	{
		[SerializeField] private AudioSource _audioSource;

		public void Setup(AudioClip audioClip)
		{
			_audioSource.clip = audioClip;

			_audioSource.Play();

			Destroy(gameObject, audioClip.length);
		}
	}
}