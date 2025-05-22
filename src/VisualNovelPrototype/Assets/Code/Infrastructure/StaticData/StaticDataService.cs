using System;
using System.Collections.Generic;
using System.Linq;
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
		
		private Dictionary<WindowId, WindowConfig> _windowById;
		private Dictionary<QuestTypeId, QuestConfig> _questById;
		
		private readonly IAssetProvider _assetProvider;

		public StaticDataService(IAssetProvider assetProvider) =>
			_assetProvider = assetProvider;

		public async UniTask Load()
		{
			await LoadWindows();
			await LoadQuests();
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

		private async UniTask LoadWindows() =>
			_windowById = (await _assetProvider.LoadAll<WindowConfig>(WindowConfigLabel))
				.ToDictionary(x => x.TypeId, x => x);

		private async UniTask LoadQuests() =>
			_questById = (await _assetProvider.LoadAll<QuestConfig>(QuestConfigLabel))
				.ToDictionary(x => x.Id, x => x);
	}
}