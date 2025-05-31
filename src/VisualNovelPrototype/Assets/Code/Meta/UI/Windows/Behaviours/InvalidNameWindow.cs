using Code.Audio.SoundEffects;
using Code.Audio.SoundEffects.Factory;
using Code.Gameplay.Quest;
using Code.Meta.UI.Windows.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Windows.Behaviours
{
	public class InvalidNameWindow : BaseWindow
	{
		[SerializeField] private Button _closeButton;

		private IWindowService _windowService;
		private ISoundEffectFactory _soundEffectFactory;

		[Inject]
		public void Constructor(IWindowService windowService, ISoundEffectFactory soundEffectFactory)
		{
			Id = WindowId.InvalidNameWindow;

			_windowService = windowService;
			_soundEffectFactory = soundEffectFactory;
		}

		protected override void Initialize()
		{
			_soundEffectFactory.CreateSoundEffect(SoundEffectTypeId.Error);

			_closeButton.onClick.AddListener(CloseWindow);
		}

		private void CloseWindow() => 
			_windowService.Close(WindowId.InvalidNameWindow);
	}
}