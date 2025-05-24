using Code.Gameplay.Quest;
using UnityEngine;
using Zenject;

namespace Code.Meta.UI.Windows.Behaviours
{
	public class MinigameWindow : BaseWindow
	{
		[SerializeField] private Transform _cardsHolder;

		private IMinigameService _minigameService;

		[Inject]
		public void Constructor(IMinigameService minigameService)
		{
			Id = WindowId.MinigameWindow;

			_minigameService = minigameService;
		}

		protected override void OnAwake() => 
			_minigameService.SetCardsHolder(_cardsHolder);
	}
}