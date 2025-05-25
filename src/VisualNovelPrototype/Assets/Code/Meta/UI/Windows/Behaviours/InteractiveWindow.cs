using Code.Gameplay.IntearctiveObject.Commands;
using UnityEngine;
using Zenject;

namespace Code.Meta.UI.Windows.Behaviours
{
	public class InteractiveWindow : BaseWindow
	{
		[SerializeField] private Transform _holder;

		[Inject]
		public void Constructor(IInteractiveObjectFactory factory)
		{
			Id = WindowId.InteractiveWindow;

			factory.SetHolder(_holder);
		}
	}
}