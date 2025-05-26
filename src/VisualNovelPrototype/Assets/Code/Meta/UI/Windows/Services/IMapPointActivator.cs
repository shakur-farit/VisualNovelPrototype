namespace Code.Meta.UI.Windows.Services
{
	public interface IMapPointActivator
	{
		bool IsFirstLocationActive { get; }
		bool IsSecondLocationActive { get; }
		void ActiveFirstLocation();
		void ActiveSecondLocation();
		void DeactiveFirstLocation();
		void DeactiveSecondLocation();
	}
}