using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Code.Gameplay.Quest.Behaviours
{
	public class QuestNotification : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _questNotificationText;

		private void Start() => 
			gameObject.SetActive(false);

		public void ShowNotification(string text)
		{
			SetupText(text);
			Show();
			Hide();
		}	

		private void SetupText(string text) => 
			_questNotificationText.text = text;

		private void Show() => 
			gameObject.SetActive(true);

		private async void Hide()
		{
			await UniTask.Delay(2000);

			gameObject.SetActive(false);
		}
	}
}