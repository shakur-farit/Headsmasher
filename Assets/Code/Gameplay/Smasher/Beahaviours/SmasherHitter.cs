using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Input
{
	public class SmasherHitter : MonoBehaviour
	{
		[SerializeField] private SmasherAnimator _animator;

		private IInputService _input;

		[Inject]
		public void Constructor(IInputService input) => 
			_input = input;

		private void Update()
		{
			if (_input.GetLeftMouseButtonDown()) 
				_animator.AnimateLeftHit();

			if (_input.GetRightMouseButtonDown()) 
				_animator.AnimateRightHit();
		}
	}
}