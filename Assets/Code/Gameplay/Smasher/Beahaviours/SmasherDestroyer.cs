using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Input
{
  public class SmasherDestroyer : MonoBehaviour
  {
    private IHeadDeathService _death;

    [Inject]
    public void Constructor(IHeadDeathService death) =>
      _death = death;

    private void OnEnable() =>
      _death.Dead += Destroy;

    private void OnDisable() =>
      _death.Dead -= Destroy;

    public void Destroy() =>
      Destroy(gameObject);
  }
}