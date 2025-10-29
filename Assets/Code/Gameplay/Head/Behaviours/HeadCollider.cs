using Assets.Code.Gameplay.SoundEffect;
using Assets.Code.Gameplay.SoundEffect.Factory;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Input
{
  public class HeadCollider : MonoBehaviour
  {
    private const int RightHandLayer = 6;
    private const int LeftHandLayer = 7;

    [SerializeField] private HeadItem _head;
    [SerializeField] private HeadAnimator _animator;

    private IScoreService _score;
    private ISoundEffectFactory _soundEffect;
    private IHeadHealthService _health;


    [Inject]
    public void Constructor(
      IHeadHealthService health,
      IScoreService score,
      ISoundEffectFactory soundEffect)
    {
      _score = score;
      _soundEffect = soundEffect;
      _health = health;
    }


    private void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.layer == RightHandLayer)
        _animator.AnimateRightPunchTaking();
      if (other.gameObject.layer == LeftHandLayer)
        _animator.AnimateLeftPunchTaking();

      _soundEffect.CreateSoundEffect(SoundEffectTypeId.Hit);
      _score.IncreaseScore(_head.PunchScore);
      _health.DecreaseCurrentHp(_head.TakenDamage);
    }
  }
}