using Assets.Code.Gameplay.Camera.Service;
using Assets.Code.Gameplay.Input;
using Assets.Code.Gameplay.SoundEffect.Factory;
using Assets.Code.Infrastructure.AssetsProvider;
using Assets.Code.Infrastructure.Loading;
using Assets.Code.Infrastructure.States.Factory;
using Assets.Code.Infrastructure.States.GameStates;
using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Infrastructure.StaticData;
using Assets.Code.Meta.UI.Windows.Factory;
using Assets.Code.Meta.UI.Windows.Service;
using Zenject;

namespace Assets.Code.Infrastructure.Installers
{
	public class BootstrapInstaller : MonoInstaller, ICoroutineRunner, IInitializable
	{
		public override void InstallBindings()
		{
			BindStateMachine();
			BindStateMachineFactory();
			BindInfrastructureServices();
			BindGameStates();
			BindGameplayServices();
			BindGameplayFactories();
			BindUIServices();
			BindUIFactories();
		}

		private void BindStateMachine() => 
			Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();

		private void BindStateMachineFactory() => 
			Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();

		private void BindGameStates()
		{
			Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
			Container.BindInterfacesAndSelfTo<LoadStaticDataState>().AsSingle();
			Container.BindInterfacesAndSelfTo<LoadingHomeScreenSceneState>().AsSingle();
			Container.BindInterfacesAndSelfTo<HomeScreenState>().AsSingle();
			Container.BindInterfacesAndSelfTo<LoadingGameplaySceneState>().AsSingle();
			Container.BindInterfacesAndSelfTo<GameplayState>().AsSingle();
			Container.BindInterfacesAndSelfTo<LevelCompleteState>().AsSingle();
			Container.BindInterfacesAndSelfTo<GameOverState>().AsSingle();
		}

		private void BindInfrastructureServices()
		{
			Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
			Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
			Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
			Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
		}

		public void BindGameplayServices()
		{
			Container.Bind<ICameraProvider>().To<CameraProvider>().AsSingle();
			Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
			Container.Bind<IScoreService>().To<ScoreService>().AsSingle();
			Container.Bind<IHeadHealthService>().To<HeadHealthService>().AsSingle();
			Container.Bind<IHeadDeathService>().To<HeadDeathService>().AsSingle();
    }

		public void BindGameplayFactories()
		{
			Container.Bind<ISoundEffectFactory>().To<SoundEffectFactory>().AsSingle();
			Container.Bind<IHeadFactory>().To<HeadFactory>().AsSingle();
			Container.Bind<ISmasherFactory>().To<SmasherFactory>().AsSingle();
		}

		public void BindUIServices() => 
			Container.Bind<IWindowService>().To<WindowService>().AsSingle();

		public void BindUIFactories() =>
			Container.Bind<IWindowFactory>().To<WindowFactory>().AsSingle();

		public void Initialize() => 
			Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
  }
}
