using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.AssetsManagement
{
	public interface IStaticDataService
	{
		UniTask Load();
		WindowConfig GetWindowConfig(WindowId id);
	}
}