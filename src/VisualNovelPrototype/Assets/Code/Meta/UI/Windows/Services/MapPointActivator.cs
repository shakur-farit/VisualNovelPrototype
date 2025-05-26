namespace Code.Meta.UI.Windows.Services
{
	public class MapPointActivator : IMapPointActivator
	{
		public bool IsFirstLocationActive { get; private set; }
		public bool IsSecondLocationActive { get; private set; }

		public void ActiveFirstLocation() =>
			IsFirstLocationActive = true;

		public void ActiveSecondLocation() =>
			IsSecondLocationActive = true;

		public void DeactiveFirstLocation() =>
			IsFirstLocationActive = false;

		public void DeactiveSecondLocation() =>
			IsSecondLocationActive = false;
	}
}