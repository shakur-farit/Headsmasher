using Assets.Code.Gameplay.Camera.Service;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Camera.Behaviours
{
	public class CameraFollow : MonoBehaviour
	{
		private ICameraProvider _cameraProvider;

		[Inject]
		public void Constructor(ICameraProvider cameraProvider) => 
			_cameraProvider = cameraProvider;

		private void Update() => 
			Follow();

		private void Follow()
		{
			if(_cameraProvider.FollowTarget == null)
				return;

			transform.position = new(
        _cameraProvider.FollowTarget.position.x,
        _cameraProvider.FollowTarget.position.y,
				_cameraProvider.FollowTarget.position.z);
		}
	}
}