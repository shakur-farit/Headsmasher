using UnityEngine;

namespace Assets.Code.Gameplay.Input
{
	public class SmasherAnimator : MonoBehaviour
	{
		[SerializeField] private Transform _leftArm;
		[SerializeField] private Transform _rightArm;

		public void AnimateLeftHit() => 
			Debug.Log("Left hit anim");
		public void AnimateRightHit() =>
			Debug.Log("Right hit anim");
	}
}