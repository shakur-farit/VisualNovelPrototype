using Code.Gameplay.Quest;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.IntearctiveObject.Commands
{
	public class InteractiveObjectItem : MonoBehaviour
	{
		[SerializeField] private Button _activateButton;

		private UniTaskCompletionSource _keyUsedTsc;

		private ISoundEffectFactory _soundEffectFactory;

		[Inject]
		public void Constructor(ISoundEffectFactory soundEffectFactory) => 
			_soundEffectFactory = soundEffectFactory;

		private void Start() => 
			_activateButton.onClick.AddListener(Use);

		public UniTask OpenTask()
		{
			_keyUsedTsc = new UniTaskCompletionSource();

			return _keyUsedTsc.Task;
		}

		private void Use()
		{
			_soundEffectFactory.CreateSoundEffect(SoundEffectTypeId.Click);

			_keyUsedTsc?.TrySetResult();

			Destroy(gameObject);
		}
	}
}