using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Configs;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.StaticData
{
	public interface IStaticDataService
	{
		UniTask Load();
		WindowConfig GetWindowConfig(WindowId id);
		QuestConfig GetQuestConfig(QuestTypeId id);
	}
}