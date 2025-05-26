using System;
using Code.Gameplay.Quest.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Quest.Behaviours
{
	public class QuestItem : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _title;
		[SerializeField] private Button _selectButton;

		private QuestStatus _status;
		private Action<string> _onSelected;

		public void Setup(QuestConfig config, Action<string> action)
		{
			_status = config.Status;
			_title.text = config.QuestName;
			_onSelected = action;

			//BindEvents(config.Description);
		}

		private void BindEvents(string description)
		{
			_selectButton.onClick.RemoveAllListeners();
			_selectButton.onClick.AddListener(() => _onSelected?.Invoke(description));
		}
	}
}