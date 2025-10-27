using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Code.Gameplay.Input
{
  public class SmasherAnimator : MonoBehaviour
  {
    private const int LeftPunch = 0;
    private const int RightPunch = 1;
    private const string LeftHandPunching = "LeftHandPunching";
    private const string RightHandPunching = "RightHandPunching";

    [SerializeField] private Animator _animator;

    private readonly int _isIdling = Animator.StringToHash("isIdling");
    private readonly int _punch = Animator.StringToHash("Punch");

    public void AnimateLeftHit()
    {
      if (IsPunching())
        return;

      _animator.SetInteger(_punch, LeftPunch);
    }

    public void AnimateRightHit()
    {
      if (IsPunching())
        return;

      _animator.SetInteger(_punch, RightPunch);
    }

    private bool IsPunching()
    {
      AnimatorStateInfo state = _animator.GetCurrentAnimatorStateInfo(0);

      if (state.IsName(LeftHandPunching) || state.IsName(RightHandPunching))
        return true;

      return false;
    }
  }
}