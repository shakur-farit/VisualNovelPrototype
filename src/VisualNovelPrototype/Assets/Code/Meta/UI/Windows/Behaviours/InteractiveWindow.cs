using Code.Meta.UI.Windows.Services;
using Naninovel;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Windows.Behaviours
{
	public class InteractiveWindow : BaseWindow
	{
		[SerializeField] private Button _keyButton;
		[SerializeField] private Button _doorButton;
		[SerializeField] private Image _doorButtonActiveIcon;
		[SerializeField] private Image _doorButtonUnactiveIcon;



		[Inject]
		public void Constructor()
		{
			Id = WindowId.InteractiveWindow;
		}

		protected override void Initialize()
		{
			_keyButton.onClick.AddListener(ActiveDoor);
			_doorButton.onClick.AddListener(UseDoor);

			UnactiveDoor();
		}

		private void ActiveDoor()
		{
			_doorButton.interactable = true;
			_doorButtonUnactiveIcon.enabled = false;
			_doorButtonActiveIcon.enabled = true;

			_keyButton.enabled = false;
		}

		private void UnactiveDoor()
		{
			_doorButton.interactable = false;
			_doorButtonUnactiveIcon.enabled = true;
			_doorButtonActiveIcon.enabled = false;
		}

		private void UseDoor()
		{
			UnactiveDoor();
		}
	}
}