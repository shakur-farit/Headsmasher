using UnityEngine;

namespace Assets.Code.Gameplay.SoundEffect.Factory
{
  public interface ISoundEffectFactory
  {
    Behaviours.SoundEffect CreateSoundEffect(SoundEffectTypeId typeId, Vector3 at);
  }
}