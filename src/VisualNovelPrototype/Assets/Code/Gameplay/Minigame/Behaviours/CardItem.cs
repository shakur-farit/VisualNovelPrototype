using Code.Gameplay.Minigame.Configs;
using Code.Gameplay.Minigame.Service;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Minigame.Behaviours
{
	public class CardItem : MonoBehaviour
	{
		[SerializeField] private Image _upIcon;
		[SerializeField] private Image _insideIcon;
		[SerializeField] private Image _selectedIcon;
		[SerializeField] private Button _selectButton;

		private CardTypeId _id;

		private IMinigameService _minigameService;

		public CardTypeId Id => _id;

		[Inject]
		public void Constructor(IMinigameService minigameService) => 
			_minigameService = minigameService;

		private void Start()
		{
			_selectButton.onClick.AddListener(SelectCard);

			HideCard();
		}

		public void Setup(CardConfig config)
		{
			_upIcon.sprite = config.UpSprite;
			_insideIcon.sprite = config.InsideSprite;
			_id = config.TypeId;
		}

		public void HideCard()
		{
			_upIcon.enabled = true;
			_insideIcon.enabled = false;

			UnselectCard();
		}

		public void ShowCard()
		{
			_upIcon.enabled = false;
			_insideIcon.enabled = true;
		}

		private void SelectCard() => 
			_minigameService.SelectCard(this, _selectedIcon);

		private void UnselectCard() => 
			_selectedIcon.enabled = false;
	}
}