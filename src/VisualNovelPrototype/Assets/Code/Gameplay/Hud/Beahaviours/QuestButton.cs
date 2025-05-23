using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Hud.Beahaviours
{
	public class QuestButton : MonoBehaviour
	{
		[SerializeField] private Button _questButton;

		private IWindowService _windowService;

		[Inject]
		public void Constructor(IWindowService windowService) => 
			_windowService = windowService;

		private void Start() => 
			_questButton.onClick.AddListener(OpenQuestWindow);

		private void OpenQuestWindow() => 
			_windowService.Open(WindowId.QuestWindow);
	}
}