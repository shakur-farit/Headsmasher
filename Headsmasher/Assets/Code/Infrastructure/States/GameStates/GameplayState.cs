using Assets.Code.Gameplay.Camera.Service;
using Assets.Code.Gameplay.Input;
using Assets.Code.Infrastructure.States.Infrastructure;
using Assets.Code.Meta.UI.Windows;
using Assets.Code.Meta.UI.Windows.Service;
using UnityEngine;

namespace Assets.Code.Infrastructure.States.GameStates
{
	public class GameplayState : IState
	{
    private readonly ICameraProvider _cameraProvider;
    private readonly IHeadFactory _headFactory;
    private readonly ISmasherFactory _smasherFactory;
    private readonly IWindowService _windowService;

		public GameplayState(
			ICameraProvider cameraProvider,
			IHeadFactory headFactory,
			ISmasherFactory smasherFactory,
			IWindowService windowService)
		{
      _cameraProvider = cameraProvider;
      _headFactory = headFactory;
      _smasherFactory = smasherFactory;
      _windowService = windowService;
		}

		public void Enter()
		{
			OpenHudWindow();

			PlayBackgroundMusic();
			CreateHead();
			GameObject smasher = CreateSmasher();
			SetCameraFollowing(smasher);
		}

		public void Exit()
		{
		}

		private void PlayBackgroundMusic()
		{
			AudioSource audioSource = _cameraProvider.MainCamera.GetComponent<AudioSource>();
			audioSource.Play();
		}

		private GameObject CreateHead() => 
			_headFactory.CreateHead();

		private GameObject CreateSmasher() => 
			_smasherFactory.CreateSmasher();

		private void SetCameraFollowing(GameObject head) => 
			_cameraProvider.SetFollowTarget(head.transform);

		private void OpenHudWindow() => 
      _windowService.Open(WindowId.Hud);
	}
}