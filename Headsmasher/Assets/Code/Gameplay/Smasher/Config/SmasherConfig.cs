using UnityEngine;

namespace Assets.Code.Gameplay.Input
{
	[CreateAssetMenu(menuName = "Headsmasher/Smasher Config", fileName = "SmasherConfig")]
	public class SmasherConfig : ScriptableObject
	{
		public GameObject Prefab;
		public Vector3 StartPosition;
	}
}