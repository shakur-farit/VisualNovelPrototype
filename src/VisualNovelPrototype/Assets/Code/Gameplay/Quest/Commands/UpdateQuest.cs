using System;
using Code.Gameplay.Quest.Service;
using Naninovel;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Quest.Commands
{
	public class UpdateQuest : Command
	{
		[ParameterAlias("id")]
		public StringParameter QuestId;

		public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
		{
			Debug.LogWarning($"{QuestId}");

			DiContainer container = ProjectContext.Instance.Container;
			IQuestUpdater questService = container.Resolve<IQuestUpdater>();

			if (Enum.TryParse<QuestTypeId>(QuestId, ignoreCase: true, out var questType))
				questService.UpdateQuest(questType);
			else
				Debug.LogWarning($"QuestAdd: Invalid QuestId '{QuestId}'");

			return UniTask.CompletedTask;
		}
	}
}