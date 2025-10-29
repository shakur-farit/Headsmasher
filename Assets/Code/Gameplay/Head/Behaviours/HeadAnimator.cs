using System.Collections;
using UnityEngine;

namespace Assets.Code.Gameplay.Input
{
  public class HeadAnimator : MonoBehaviour
  {
    private const int LeftPunch = 0;
    private const int RightPunch = 1;
    private const string LeftTakingPunch = "LeftTakingPunch";
    private const string RightTakingPunch = "RightTakingPunch";

    [SerializeField] private Animator _animator;

    private readonly int _isIdling = Animator.StringToHash("isIdling");
    private readonly int _punch = Animator.StringToHash("Punch");


    public void AnimateLeftPunchTaking() => 
      StartCoroutine(PlayPunchRoutine(LeftPunch, LeftTakingPunch));

    public void AnimateRightPunchTaking() => 
      StartCoroutine(PlayPunchRoutine(RightPunch, RightTakingPunch));

    private IEnumerator PlayPunchRoutine(int punchType, string stateName)
    {
      _animator.SetBool(_isIdling, false);
      _animator.SetInteger(_punch, punchType);

      yield return WaitForAnimationToEnd(stateName);

      _animator.SetBool(_isIdling, true);
      _animator.SetInteger(_punch, -1);
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