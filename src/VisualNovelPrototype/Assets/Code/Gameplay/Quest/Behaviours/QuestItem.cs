using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Meta.UI.Windows
{
	public class QuestItem : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _title;
		[SerializeField] private TextMeshProUGUI _description;
		[SerializeField] private Button _selectButton;

		private QuestStatus _status;
		private Action<string> _onSelected;

		public void Setup(QuestConfig config, Action<string> action)
		{
			_status = config.Status;
			_title.text = config.Title;
			_description.text = config.Description;
			_onSelected = action;

			BindEvents();
		}

		private void BindEvents()
		{
			_selectButton.onClick.RemoveAllListeners();
			_selectButton.onClick.AddListener(() => _onSelected?.Invoke(_description.text));
		}
	}
}