using Assets.Code.Infrastructure.States.Infrastructure;
using Assets.Code.Meta.UI.Windows;
using Assets.Code.Meta.UI.Windows.Service;

namespace Assets.Code.Infrastructure.States.GameStates
{
	public class HomeScreenState : IState
	{
		private readonly IWindowService _windowService;

		public HomeScreenState(IWindowService windowService) => 
			_windowService = windowService;

		public void Enter() => 
			_windowService.Open(WindowId.MainMenuWindow);

		public void Exit()
		{
		}
	}
}