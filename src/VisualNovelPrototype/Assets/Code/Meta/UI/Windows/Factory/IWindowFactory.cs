using UnityEngine;

namespace Code.Infrastructure.AssetsManagement
{
	public interface IWindowFactory
	{
		void SetUIRoot(RectTransform uiRoot);
		BaseWindow CreateWindow(WindowId windowId);
	}
}