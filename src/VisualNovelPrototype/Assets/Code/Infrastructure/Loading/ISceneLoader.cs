using System;

namespace Code.Infrastructure.States.GameStates
{
	public interface ISceneLoader
	{
		void LoadScene(string name, Action onLoaded = null);
	}
}