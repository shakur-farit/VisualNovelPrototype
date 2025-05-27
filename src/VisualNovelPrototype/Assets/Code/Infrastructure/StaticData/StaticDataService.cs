using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.IntearctiveObject.Commands;
using Code.Gameplay.Minigame;
using Code.Gameplay.Minigame.Configs;
using Code.Gameplay.Quest;
using Code.Gameplay.Quest.Configs;
using Code.Infrastructure.AssetsManagement;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Configs;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.StaticData
{
	public class StaticDataService : IStaticDataService
	{
		private const string WindowConfigLabel = "WindowConfig";
		private const string QuestConfigLabel = "QuestConfig";
		private const string CardConfigLabel = "CardConfig";
		private const string InteractiveObjectConfigLabel = "InteractiveObjectConfig";
		private const string SoundEffectConfigLabel = "SoundEffectConfig";
		
		private Dictionary<WindowId, WindowConfig> _windowById;
		private Dictionary<QuestTypeId, QuestConfig> _questById;
		private Dictionary<CardTypeId, CardConfig> _cardById;
		private Dictionary<InteractiveObjectTypeId, InteractiveObjectConfig> _interactiveObjectById;
		private Dictionary<SoundEffectTypeId, SoundEffectConfig> _soundEffectById;

		private readonly IAssetProvider _assetProvider;

		public StaticDataService(IAssetProvider assetProvider) =>
			_assetProvider = assetProvider;

		public async UniTask Load()
		{
			await LoadWindows();
			await LoadQuests();
			await LoadCards();
			await LoadInteractiveObjects();
			await LoadSoundEffectObjects();
		}

		public WindowConfig GetWindowConfig(WindowId id)
		{
			if (_windowById.TryGetValue(id, out WindowConfig config))
				return config;

			throw new Exception($"Window config for {id} was not found");
		}

		public QuestConfig GetQuestConfig(QuestTypeId id)
		{
			if (_questById.TryGetValue(id, out QuestConfig config))
				return config;

			throw new Exception($"Quest config for {id} was not found");
		}

		public CardConfig GetCardConfig(CardTypeId id)
		{
			if (_cardById.TryGetValue(id, out CardConfig config))
				return config;

			throw new Exception($"Card config for {id} was not found");
		}

		public InteractiveObjectConfig GetInteractiveObjectConfig(InteractiveObjectTypeId id)
		{
			if (_interactiveObjectById.TryGetValue(id, out InteractiveObjectConfig config))
				return config;

			throw new Exception($"Interactive object config for {id} was not found");
		}

		public SoundEffectConfig GetSoundEffectConfig(SoundEffectTypeId id)
		{
			if (_soundEffectById.TryGetValue(id, out SoundEffectConfig config))
				return config;

			throw new Exception($"Sound effect config for {id} was not found");
		}

		private async UniTask LoadWindows() =>
			_windowById = (await _assetProvider.LoadAll<WindowConfig>(WindowConfigLabel))
				.ToDictionary(x => x.TypeId, x => x);

		private async UniTask LoadQuests() =>
			_questById = (await _assetProvider.LoadAll<QuestConfig>(QuestConfigLabel))
				.ToDictionary(x => x.Id, x => x);

		private async UniTask LoadCards() =>
			_cardById = (await _assetProvider.LoadAll<CardConfig>(CardConfigLabel))
				.ToDictionary(x => x.TypeId, x => x);

		private async UniTask LoadInteractiveObjects() =>
			_interactiveObjectById = (await _assetProvider.LoadAll<InteractiveObjectConfig>(InteractiveObjectConfigLabel))
				.ToDictionary(x => x.TypeId, x => x);

		private async UniTask LoadSoundEffectObjects() =>
			_soundEffectById = (await _assetProvider.LoadAll<SoundEffectConfig>(SoundEffectConfigLabel))
				.ToDictionary(x => x.TypeId, x => x);
	}
}