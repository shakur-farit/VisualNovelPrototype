using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Quest
{
	public class CardItem : MonoBehaviour
	{
		[SerializeField] private Image _upIcon;
		[SerializeField] private Image _insideIcon;
		[SerializeField] private Image _selectedIcon;

		private CardTypeId _id;

		public void Setup(CardConfig config)
		{
			_upIcon.sprite = config.UpSprite;
			_insideIcon.sprite = config.InsideSprite;
			_id = config.TypeId;
		}
	}
}