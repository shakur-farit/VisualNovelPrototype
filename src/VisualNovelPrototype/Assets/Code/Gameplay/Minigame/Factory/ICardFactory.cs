using Code.Gameplay.Minigame.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Minigame.Factory
{
	public interface ICardFactory
	{
		CardItem CreateCardItem(CardTypeId id, Transform parent);
	}
}