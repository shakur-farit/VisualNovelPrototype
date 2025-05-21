namespace Code.Infrastructure.AssetsManagement
{
	public interface IWindowService
	{
		void Open(WindowId windowId);
		void Close(WindowId windowId);
	}
}