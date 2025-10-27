using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.Gameplay.SoundEffect.Behaviours
{
  public class SoundEffectDestructor : MonoBehaviour
  {
    private const int DestructDelay = 2000;

    private void Start() => 
      Destruct();

    private async void Destruct()
    {
      await UniTask.Delay(DestructDelay);

      Destroy(gameObject);
    }
  }
}