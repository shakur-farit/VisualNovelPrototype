using System;

namespace Code.Gameplay.Quest.Service
{
	public interface IQuestDescriptionUpdater
	{
		event Action<string> OnActiveLevelSelected;
	}
}