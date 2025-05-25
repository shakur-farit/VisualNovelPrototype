using Code.Gameplay.IntearctiveObject.Commands;
using Code.Gameplay.Minigame.Factory;
using Code.Gameplay.Minigame.Service;
using Code.Gameplay.Quest.Factory;
using Code.Gameplay.Quest.Service;
using Code.Infrastructure.AssetsManagement;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.StaticData;
using Code.Meta.UI.Windows.Factory;
using Code.Meta.UI.Windows.Services;
using Code.Progress.Provider;
using Zenject;

namespace Code.Infrastructure.Installers
{
	public class BootstrapInstaller : MonoInstaller, ICoroutineRunner, IInitializable
	{
		public override void InstallBindings()
		{
			BindStateMachine();
			BindStateFactory();
			BindGameStates();
			BindInfrastructureServices();
			BindAssetManagementServices();
			BindCommonServices();
			BindProgressServices();
			BindGameplayServices();
			BindGameplayFactories();
			BindUIFactories();
			BindUIServices();
		}

		private void BindStateMachine()
		{
			Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
		}

		private void BindStateFactory()
		{
			Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
		}

		private void BindGameStates()
		{
			Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
			Container.BindInterfacesAndSelfTo<InitializeProgressState>().AsSingle();
			Container.BindInterfacesAndSelfTo<LoadStaticDataState>().AsSingle();
			Container.BindInterfacesAndSelfTo<LoadingMainMenuState>().AsSingle();
			Container.BindInterfacesAndSelfTo<MainMenuState>().AsSingle();
			Container.BindInterfacesAndSelfTo<LoadingGameplayState>().AsSingle();
			Container.BindInterfacesAndSelfTo<GameplayState>().AsSingle();
		}

		private void BindProgressServices() => 
			Container.Bind<IProgressProvider>().To<ProgressProvider>().AsSingle();

		private void BindGameplayServices()
		{
			Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
			Container.Bind<IQuestService>().To<QuestService>().AsSingle();
			Container.Bind<IMinigameService>().To<MinigameService>().AsSingle();
		}

		private void BindGameplayFactories()
		{
			Container.Bind<IQuestItemFactory>().To<QuestItemFactory>().AsSingle();
			Container.Bind<ICardFactory>().To<CardFactory>().AsSingle();
			Container.Bind<IInteractiveObjectFactory>().To<InteractiveObjectFactory>().AsSingle();
		}


		private void BindUIFactories()
		{
			Container.Bind<IWindowFactory>().To<WindowFactory>().AsSingle();
		}

		private void BindUIServices()
		{
			Container.Bind<IWindowService>().To<WindowService>().AsSingle();
		}


		private void BindInfrastructureServices()
		{
			Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
		}

		private void BindAssetManagementServices()
		{
			Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
		}

		private void BindCommonServices()
		{
			Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
		}


		public void Initialize()
		{
			Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
		}
	}
}
