using UnityEngine;

namespace Assets.Code.Gameplay.Input
{
	[CreateAssetMenu(menuName = "Headsmasher/Head Config", fileName = "HeadConfig")]
	public class HeadConfig : ScriptableObject
	{
		public GameObject Prefab;
		public Vector3 StartPosition;
	}
}