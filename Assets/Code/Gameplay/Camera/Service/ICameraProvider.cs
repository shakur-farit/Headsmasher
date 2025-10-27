using UnityEngine;

namespace Assets.Code.Gameplay.Camera.Service
{
	public interface ICameraProvider
	{
		UnityEngine.Camera MainCamera { get; }
		Transform FollowTarget { get; }
		void SetMainCamera(UnityEngine.Camera mainCamera);
		void SetFollowTarget(Transform followTarget);
	}
}