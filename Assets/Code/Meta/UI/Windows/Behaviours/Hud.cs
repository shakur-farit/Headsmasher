using Assets.Code.Gameplay.Input;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Code.Meta.UI.Windows.Behaviours
{
	public class Hud : BaseWindow
	{
		[SerializeField] private TextMeshProUGUI _scoreText;

		private IScoreService _score;


		[Inject]
		public void Constructor(IScoreService score)
		{
			Id = WindowId.Hud;

			_score = score;
		}

		protected override void SubscribeUpdates() => 
			_score.ScoreChanged += ScoreTextUpdate;

		protected override void UnsubscribeUpdates() =>
			_score.ScoreChanged -= ScoreTextUpdate;

		private void ScoreTextUpdate() => 
			_scoreText.text = $"Score: {_score.GetScore()}";
	}
}