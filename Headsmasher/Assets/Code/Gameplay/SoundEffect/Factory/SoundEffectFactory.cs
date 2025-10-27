using Assets.Code.Gameplay.SoundEffect.Config;
using Assets.Code.Infrastructure.StaticData;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.SoundEffect.Factory
{
  public class SoundEffectFactory : ISoundEffectFactory
  {
    private readonly IStaticDataService _staticDataService;
    private readonly IInstantiator _instantiator;

    public SoundEffectFactory(IStaticDataService staticDataService, IInstantiator instantiator)
    {
      _staticDataService = staticDataService;
      _instantiator = instantiator;
    }

    public Behaviours.SoundEffect CreateSoundEffect(SoundEffectTypeId typeId, Vector3 at)
    {
      SoundEffectConfig config = _staticDataService.GetSoundEffectConfig(typeId);

      Behaviours.SoundEffect soundEffect =
        _instantiator.InstantiatePrefabForComponent<Behaviours.SoundEffect>(config.Prefab, at, Quaternion.identity, null);

      soundEffect
        .Setup(config.AudioClip);

      return soundEffect;
    }
  }
}