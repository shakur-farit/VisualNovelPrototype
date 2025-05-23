using Code.Meta.UI.Windows.Services;
using Naninovel;
using UnityEngine;
using Zenject;

namespace Code.Meta.UI.Windows
{
	public class ShowHud : Command 
	{
		public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
		{
			DiContainer container = ProjectContext.Instance.Container;
			IWindowService windowService = container.Resolve<IWindowService>();
			windowService.Open(WindowId.Hud);
			return UniTask.CompletedTask;
		}
	}
}