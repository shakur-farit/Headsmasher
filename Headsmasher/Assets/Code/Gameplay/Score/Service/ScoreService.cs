using System;

namespace Assets.Code.Gameplay.Input
{
	public class ScoreService : IScoreService
	{
		public event Action ScoreChanged;

		private int _score;

		public int GetScore() => 
			_score;

		public void IncreaseScore(int score)
		{
			_score += score;

			ScoreChanged?.Invoke();
		}
	}
}