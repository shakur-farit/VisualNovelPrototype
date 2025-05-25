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
		
		private void Start() => 
			_activateButton.onClick.AddListener(UseKye);

		public UniTask OpenTask()
		{
			_keyUsedTsc = new UniTaskCompletionSource();

			return _keyUsedTsc.Task;
		}

		private void UseKye()
		{
			_keyUsedTsc?.TrySetResult();

			Destroy(gameObject);
		}
	}
}