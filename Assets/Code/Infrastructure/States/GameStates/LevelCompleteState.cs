using Assets.Code.Gameplay.Input;
using Assets.Code.Infrastructure.States.Infrastructure;
using Assets.Code.Meta.UI.Windows;
using Assets.Code.Meta.UI.Windows.Service;

namespace Assets.Code.Infrastructure.States.GameStates
{
	public class LevelCompleteState : IState
	{
    private readonly IWindowService _windowService;
    private readonly IScoreService _score;

    public LevelCompleteState(IWindowService windowService, IScoreService score)
    {
      _windowService = windowService;
      _score = score;
    }

    public void Enter()
    {
      _score.Reset();
	    _windowService.Close(WindowId.Hud);
			_windowService.Open(WindowId.LevelCompleteWindow);
    }

    public void Exit()
		{
		}
	}
}