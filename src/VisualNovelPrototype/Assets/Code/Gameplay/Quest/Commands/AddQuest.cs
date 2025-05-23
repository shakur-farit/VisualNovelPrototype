using Naninovel;
using System;
using UnityEngine;
using Zenject;

namespace Code.Meta.UI.Windows
{
	public class AddQuest : Command
	{
		[ParameterAlias("QuestId")]
		public string QuestId;

		public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
		{
			Debug.LogWarning($"{QuestId}");

			DiContainer container = ProjectContext.Instance.Container;
			IQuestService questService = container.Resolve<IQuestService>();

			if (Enum.TryParse<QuestTypeId>(QuestId, ignoreCase: true, out var questType))
				questService.AddQuest(questType);
			else
				Debug.LogWarning($"QuestAdd: Invalid QuestId '{QuestId}'");

			return UniTask.CompletedTask;
		}
	}
}