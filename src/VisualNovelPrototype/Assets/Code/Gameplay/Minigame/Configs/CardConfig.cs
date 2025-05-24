using UnityEngine;

namespace Code.Gameplay.Minigame.Configs
{
	[CreateAssetMenu(menuName = "Novel/Card Config", fileName = "CardConfig")]
	public class CardConfig : ScriptableObject
	{
		public CardTypeId TypeId;
		public Sprite UpSprite;
		public Sprite InsideSprite;
		public GameObject ViewPrefab;
	}
}