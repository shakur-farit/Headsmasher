using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.Gameplay.SoundEffect.Behaviours
{
  public class SoundEffectDestructor : MonoBehaviour
  {
	  [SerializeField] private SoundEffect _soundEffect;

    private void Start() => 
      Destruct();

    private async void Destruct()
    {
      await UniTask.Delay(_soundEffect.GetLifetime());

      Destroy(gameObject);
    }
  }
}