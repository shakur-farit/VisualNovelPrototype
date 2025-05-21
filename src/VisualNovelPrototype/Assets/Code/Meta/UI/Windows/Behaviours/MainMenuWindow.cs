using Code.Infrastructure.Loading;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Meta.UI.Windows.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Windows.Behaviours
{
	public class MainMenuWindow : BaseWindow
	{
		[SerializeField] private Button _startGameButton;

		private IGameStateMachine _stateMachine;
		private IWindowService _windowService;

		[Inject]
		public void Constructor(IGameStateMachine stateMachine, IWindowService windowService)
		{
			Id = WindowId.MainMenuWindow;

			_stateMachine = stateMachine;
			_windowService = windowService;
		}

		protected override void Initialize()
		{
			_startGameButton.onClick.AddListener(EnterToGameplay);
			_startGameButton.onClick.AddListener(CloseWindow);
		}

		private void EnterToGameplay() =>
			_stateMachine.Enter<LoadingGameplayState, string>(Scenes.Gameplay);

		private void CloseWindow() =>
			_windowService.Close(WindowId.MainMenuWindow);
	}
}