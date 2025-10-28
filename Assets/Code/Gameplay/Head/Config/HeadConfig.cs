using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Code.Gameplay.Input
{
	[CreateAssetMenu(menuName = "Headsmasher/Head Config", fileName = "HeadConfig")]
	public class HeadConfig : ScriptableObject
	{
		public GameObject Prefab;
		public Vector3 StartPosition;
		public int CurrentHp;
		public int MaxHp;
		public int PunchScore;
		public int TakenDamage;
	}
}