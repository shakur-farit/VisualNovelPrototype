using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Quest.Behaviours
{
	public class QuestLevelItem : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _tittle;
		[SerializeField] private Image _activeIcon;
		[SerializeField] private Image _deactiveIcon;

		public void Setup(string tittle, QuestLevelStatus levelStatus)
		{
			_tittle.text = tittle;

			if(levelStatus == QuestLevelStatus.Active)
				Active();
			else
				Deactive();
		}

		private void Active()
		{
			_activeIcon.enabled = true;
			_deactiveIcon.enabled = false;
		}

		private void Deactive()
		{
			_activeIcon.enabled = false;
			_deactiveIcon.enabled = true;
		}
	}
}