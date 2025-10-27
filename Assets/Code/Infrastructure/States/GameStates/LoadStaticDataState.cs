using Assets.Code.Infrastructure.States.Infrastructure;
using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Infrastructure.StaticData;

namespace Assets.Code.Infrastructure.States.GameStates
{
	public class LoadStaticDataState : IState
	{
		private readonly IGameStateMachine _gameStateMachine;
		private readonly IStaticDataService _staticDataService;

		public LoadStaticDataState(IGameStateMachine gameStateMachine, IStaticDataService staticDataService)
		{
			_gameStateMachine = gameStateMachine;
			_staticDataService = staticDataService;
		}

		public async void Enter()
		{
			await _staticDataService.LoadAll();

			_gameStateMachine.Enter<LoadingHomeScreenSceneState>();
		}

		public void Exit()
		{
			
		}
	}
}