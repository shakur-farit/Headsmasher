using Assets.Code.Gameplay.Camera.Service;
using UnityEngine;
using Zenject;

namespace Assets.Code.Infrastructure.Installers
{
	public class LevelInitializer : MonoBehaviour, IInitializable
	{
		[SerializeField] private Camera _mainCamera;
		private ICameraProvider _cameraProvider;

		[Inject]
		private void Construct(ICameraProvider cameraProvider) =>
			_cameraProvider = cameraProvider;

		public void Initialize() => 
			_cameraProvider.SetMainCamera(_mainCamera);
	}
}