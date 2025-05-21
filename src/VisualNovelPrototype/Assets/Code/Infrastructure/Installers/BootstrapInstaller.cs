using Code.Infrastructure.AssetsManagement;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Zenject;

namespace Code.Infrastructure.Installers
{
	public class BootstrapInstaller : MonoInstaller, IInitializable
	{
		public override void InstallBindings()
		{
			BindStateMachine();
			BindStateFactory();
			BindGameStates();
			BindInfrastructureServices();
		}

		private void BindStateMachine() =>
			Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();

		private void BindStateFactory() =>
			Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();

		private void BindGameStates()
		{
			Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
		}

		private void BindAssetManagementServices() => 
			Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();

		private void BindInfrastructureServices() => 
			Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();

		public void Initialize()
		{
		
		}
	}
}
