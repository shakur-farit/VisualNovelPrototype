using Code.Gameplay.IntearctiveObject.Commands;
using Code.Gameplay.Minigame;
using Code.Gameplay.Minigame.Configs;
using Code.Gameplay.Quest;
using Code.Gameplay.Quest.Configs;
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
		CardConfig GetCardConfig(CardTypeId id);
		InteractiveObjectConfig GetInteractiveObjectConfig(InteractiveObjectTypeId id);
		SoundEffectConfig GetSoundEffectConfig(SoundEffectTypeId id);
	}
}