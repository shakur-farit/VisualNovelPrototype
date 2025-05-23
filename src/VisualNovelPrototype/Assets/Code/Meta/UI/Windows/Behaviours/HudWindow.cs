using Zenject;

namespace Code.Meta.UI.Windows.Behaviours
{
	public class HudWindow : BaseWindow
	{
		[Inject]
		public void Constructor()
		{
			Id = WindowId.Hud;
		}
	}
}