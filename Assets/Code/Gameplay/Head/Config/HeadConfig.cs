using UnityEngine;

namespace Assets.Code.Gameplay.Input
{
	[CreateAssetMenu(menuName = "Headsmasher/Head Config", fileName = "HeadConfig")]
	public class HeadConfig : ScriptableObject
	{
		public GameObject Prefab;
		public Vector3 StartPosition;
		[Range(1f, 100f)] public float CurrentHp;
    [Range(1f, 100f)] public float MaxHp;
    [Range(1f, 100f)] public int PunchScore;
		[Range(1f, 100f)] public int TakenDamage;

    private void OnValidate()
    {
      if(CurrentHp > MaxHp)
        MaxHp = CurrentHp;
    }
  }
}