using Assets.Code.Gameplay.Input;
using Assets.Code.Infrastructure.States.Infrastructure;
using Assets.Code.Meta.UI.Windows;
using Assets.Code.Meta.UI.Windows.Service;

namespace Assets.Code.Infrastructure.States.GameStates
{
	public class GameplayState : IState
	{
    private readonly IHeadFactory _headFactory;
    private readonly ISmasherFactory _smasherFactory;
    private readonly IWindowService _windowService;

		public GameplayState(
			IHeadFactory headFactory,
			ISmasherFactory smasherFactory,
			IWindowService windowService)
		{
      _headFactory = headFactory;
      _smasherFactory = smasherFactory;
      _windowService = windowService;
		}

		public void Enter()
		{
			OpenHudWindow();

			CreateHead();
			CreateSmasher();
    }

		public void Exit()
		{
		}

		private void CreateHead() => 
			_headFactory.CreateHead();

		private void CreateSmasher() => 
			_smasherFactory.CreateSmasher();

    private void OpenHudWindow() => 
      _windowService.Open(WindowId.Hud);
	}
}