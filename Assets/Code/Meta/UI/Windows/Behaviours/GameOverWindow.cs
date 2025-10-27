using Assets.Code.Infrastructure.Loading;
using Assets.Code.Infrastructure.States.GameStates;
using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Meta.UI.Windows.Service;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Code.Meta.UI.Windows.Behaviours
{
  public class GameOverWindow : BaseWindow
  {
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _quitButton;

    private IGameStateMachine _stateMachine;
    private IWindowService _windowService;

    [Inject]
    public void Constructor(
	    IGameStateMachine stateMachine, 
	    IWindowService windowService)
    {
      Id = WindowId.GameOverWindow;

      _stateMachine = stateMachine;
      _windowService = windowService;
    }

    protected override void Initialize()
    {
      _restartButton.onClick.AddListener(EnterToBattle);
      _quitButton.onClick.AddListener(QuitGame);

    }

    private void EnterToBattle()
    {
      CloseWindow();
      _stateMachine.Enter<LoadingGameplaySceneState, string>(Scenes.Gameplay);
    }

    private void QuitGame()
    {
      CloseWindow();

#if UNITY_EDITOR
      UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

    private void CloseWindow() =>
      _windowService.Close(WindowId.GameOverWindow);
  }
}