using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Input
{
	public class HeadItem : MonoBehaviour
	{
		private int _punchScore;
		private int _takenDamage;

		private IHeadHealthService _health;

		public  int TakenDamage => _takenDamage;
		public int PunchScore => _punchScore;


		[Inject]
		public void Constructor(IHeadHealthService health) => 
			_health = health;

		public void Setup(float currentHp, float maxHp, int score, int takenDamage)
		{
			_health.SetHp(currentHp, maxHp);
			_punchScore = score;
			_takenDamage = takenDamage;
		}
	}
}