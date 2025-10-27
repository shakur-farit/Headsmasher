using Assets.Code.Gameplay.Camera.Service;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Input
{
  public class CameraFollowingTargetSetter : MonoBehaviour
  {
    [SerializeField] private Transform _cameraFollowingTarget;

    private ICameraProvider _cameraProvider;

    [Inject]
    public void Constructor(ICameraProvider cameraProvider) => 
      _cameraProvider = cameraProvider;

    private void Start() => 
      _cameraProvider.SetFollowTarget(_cameraFollowingTarget);
  }
}