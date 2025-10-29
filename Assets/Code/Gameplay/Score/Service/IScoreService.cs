using System;

namespace Assets.Code.Gameplay.Input
{
	public interface IScoreService
	{
		event Action ScoreChanged;
		int GetScore();
		void IncreaseScore(int score);
    void Reset();
  }
}