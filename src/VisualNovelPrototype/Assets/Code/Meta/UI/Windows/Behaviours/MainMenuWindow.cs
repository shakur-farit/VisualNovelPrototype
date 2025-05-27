using Code.Infrastructure.Loading;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Meta.UI.Windows.Services;
using System.Text.RegularExpressions;
using Code.Gameplay.Quest;
using Code.Progress.Provider;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Windows.Behaviours
{
	public class MainMenuWindow : BaseWindow
	{
		[SerializeField] private Button _startGameButton;
		[SerializeField] private TMP_InputField _nameInput;

		private const int MaxNameLength = 12;
		private readonly Regex _nameRegex = new("^[a-zA-Z0-9]+$");
		private string _name;
		private bool _isValidName;

		private IGameStateMachine _stateMachine;
		private IWindowService _windowService;
		private IProgressProvider _progressProvider;
		private ISoundEffectFactory _soundEffectFactory;

		[Inject]
		public void Constructor(
			IGameStateMachine stateMachine, 
			IWindowService windowService,
			IProgressProvider progressProvider,
			ISoundEffectFactory soundEffectFactory)
		{
			Id = WindowId.MainMenuWindow;

			_stateMachine = stateMachine;
			_windowService = windowService;
			_progressProvider = progressProvider;
			_soundEffectFactory = soundEffectFactory;
		}

		protected override void Initialize()
		{
			_startGameButton.onClick.AddListener(TryEnterTheGame);

			_nameInput.onValueChanged.AddListener(InputName);
		}

		private void TryEnterTheGame()
		{
			_soundEffectFactory.CreateSoundEffect(SoundEffectTypeId.Click);

			if(_isValidName)
			{
				SavePlayerName(_name);
				EnterToGameplay();
			}
			else
			{
				OpenInvalidNameWindow();
			}
		}

		private void SavePlayerName(string input) => 
			_progressProvider.ProgressData.PlayerData.PlayerName = input;

		private void EnterToGameplay() =>
			_stateMachine.Enter<LoadingGameplayState, string>(Scenes.Gameplay);

		private void CloseWindow() =>
			_windowService.Close(WindowId.MainMenuWindow);

		private void InputName(string input)
		{
			_isValidName = string.IsNullOrWhiteSpace(input) == false
			               && input.Length <= MaxNameLength
			               && _nameRegex.IsMatch(input);

			if (_isValidName)
				_name = input;
		}

		private void OpenInvalidNameWindow() => 
			_windowService.Open(WindowId.InvalidNameWindow);
	}
}