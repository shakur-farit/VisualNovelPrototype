using UnityEngine;

namespace Code.Gameplay.Quest
{
	public interface ICardFactory
	{
		CardItem CreateCardItem(CardTypeId id, Transform parent);
	}
}