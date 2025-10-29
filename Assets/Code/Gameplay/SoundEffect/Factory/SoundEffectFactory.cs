using Assets.Code.Gameplay.SoundEffect.Config;
using Assets.Code.Infrastructure.StaticData;
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

    public Behaviours.SoundEffect CreateSoundEffect(SoundEffectTypeId typeId)
    {
      SoundEffectConfig config = _staticDataService.GetSoundEffectConfig(typeId);

      Behaviours.SoundEffect soundEffect =
        _instantiator.InstantiatePrefabForComponent<Behaviours.SoundEffect>(config.Prefab);

      soundEffect
        .Setup(config.AudioClip, config.Lifetime);

      return soundEffect;
    }
  }
}