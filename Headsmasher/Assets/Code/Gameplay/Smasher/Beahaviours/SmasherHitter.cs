using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Input
{
	public class SmasherHitter : MonoBehaviour
	{
		private const int ScoreForHit = 10;

		[SerializeField] private SmasherAnimator _animator;

		private IInputService _input;
		private IScoreService _score;

		[Inject]
		public void Constructor(IInputService input, IScoreService score)
		{
			_input = input;
			_score = score;
		}

		private void Update()
		{
			if (_input.GetLeftMouseButtonDown())
			{
				_animator.AnimateLeftHit();
				_score.IncreaseScore(ScoreForHit);
			}

			if (_input.GetRightMouseButtonDown())
			{
				_animator.AnimateRightHit();
				_score.IncreaseScore(ScoreForHit);
			}
		}
	}
}