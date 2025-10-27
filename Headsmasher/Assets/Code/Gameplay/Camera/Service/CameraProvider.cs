using UnityEngine;

namespace Assets.Code.Gameplay.Camera.Service
{
	public class CameraProvider : ICameraProvider
	{
		public UnityEngine.Camera MainCamera { get; private set; }
		public Transform FollowTarget { get; private set; }

		public void SetMainCamera(UnityEngine.Camera mainCamera) => 
			MainCamera = mainCamera;

		public void SetFollowTarget(Transform followTarget) => 
			FollowTarget = followTarget;
	}
}