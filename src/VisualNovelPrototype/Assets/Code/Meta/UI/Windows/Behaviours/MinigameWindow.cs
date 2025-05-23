using UnityEngine;
using Zenject;

namespace Code.Meta.UI.Windows.Behaviours
{
	public class MinigameWindow : BaseWindow
	{
		[SerializeField] private Transform _cardsHolder;

		[Inject]
		public void Constructor()
		{
			Id = WindowId.MinigameWindow;
		}
	}
}