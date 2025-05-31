using Code.Extensions;
using Code.Gameplay.Quest.Configs;
using Code.Gameplay.Quest.Service;
using Code.Progress.Provider;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Quest.Behaviours
{
	public class QuestItem : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _title;
		[SerializeField] private Button _selectButton;

		private IQuestShower _questService;

		[Inject]
		public void Constructor(IQuestShower questService) => 
			_questService = questService;

		public void Setup(QuestConfig config)
		{
			_title.text = config.Id.ToReadableString();

			_selectButton.onClick.RemoveAllListeners();
			_selectButton.onClick.AddListener(() => OnClicked(config));
		}

		private void OnClicked(QuestConfig config)
		{
			_questService.ShowQuestLevels(config.Id);
		}
	}
}