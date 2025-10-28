using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Input
{
	public class HeadCollider : MonoBehaviour
	{
		private const int ScoreIncreaseValue = 10;
		private const int RightHandLayer = 6;
		private const int LeftHandLayer = 7;

		private IScoreService _score;

		[Inject]
		public void Constructor(IScoreService score) => 
			_score = score;

		private void OnTriggerEnter(Collider other)
		{
			if(other.gameObject.layer == RightHandLayer)
				Debug.Log("Right");
			if (other.gameObject.layer == LeftHandLayer)
				Debug.Log("Left"); 
			_score.IncreaseScore(ScoreIncreaseValue);
		}
	}
}