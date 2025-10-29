using System.Collections;
using UnityEngine;

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

    private bool _isPunching;

    public void AnimateLeftHit()
    {
      if (_isPunching)
        return;

      StartCoroutine(PlayPunchRoutine(LeftPunch, LeftHandPunching));
    }

    public void AnimateRightHit()
    {
      if (_isPunching)
        return;

      StartCoroutine(PlayPunchRoutine(RightPunch, RightHandPunching));
    }

    private IEnumerator PlayPunchRoutine(int punchType, string stateName)
    {
      _isPunching = true;

      _animator.SetBool(_isIdling, false);
      _animator.SetInteger(_punch, punchType);

      yield return WaitForAnimationToEnd(stateName);

      _animator.SetBool(_isIdling, true);
      _animator.SetInteger(_punch, -1);

      _isPunching = false;
    }

    private IEnumerator WaitForAnimationToEnd(string stateName)
    {
      AnimatorStateInfo state = _animator.GetCurrentAnimatorStateInfo(0);

      while (!state.IsName(stateName))
      {
        yield return null;
        state = _animator.GetCurrentAnimatorStateInfo(0);
      }
    }
  }
}