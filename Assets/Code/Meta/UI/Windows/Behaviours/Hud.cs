using Assets.Code.Gameplay.Input;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Code.Meta.UI.Windows.Behaviours
{
	public class Hud : BaseWindow
	{
		[SerializeField] private TextMeshProUGUI _scoreText;
		[SerializeField] private TextMeshProUGUI _hpText;

		private IScoreService _score;
		private IHeadHealthService _headHealth;


		[Inject]
		public void Constructor(IScoreService score, IHeadHealthService headHealth)
		{
			Id = WindowId.Hud;

			_score = score;
			_headHealth = headHealth;
		}

		protected override void SubscribeUpdates()
		{
			_score.ScoreChanged += UpdateScoreText;
			_headHealth.HealthChanged += UpdateHpText;
		}

		protected override void UnsubscribeUpdates()
		{
			_score.ScoreChanged -= UpdateScoreText;
			_headHealth.HealthChanged += UpdateHpText;
		}

		private void UpdateHpText()
		{
			int hp = _headHealth.CurrentHp / _headHealth.MaxHp * 100;

			_hpText.text = $"Health: {hp}%";
		}

		private void UpdateScoreText() => 
			_scoreText.text = $"Score: {_score.GetScore()}";
	}
}