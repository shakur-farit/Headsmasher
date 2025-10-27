using Assets.Code.Infrastructure.AssetsProvider;
using Assets.Code.Infrastructure.States.Infrastructure;
using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Infrastructure.StaticData;

namespace Assets.Code.Infrastructure.States.GameStates
{
	public class BootstrapState : IState
	{
		private readonly IGameStateMachine _stateMachine;
		private readonly IAssetProvider _assetProvider;

		public BootstrapState(
			IGameStateMachine stateMachine, 
			IAssetProvider assetProvider)
		{
			_stateMachine = stateMachine;
			_assetProvider = assetProvider;
		}

		public async void Enter()
		{
			await _assetProvider.Initialize();

			_stateMachine.Enter<LoadStaticDataState>();
		}

		public void Exit()
		{
		}
	}
}