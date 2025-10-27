using UnityEngine;

namespace Assets.Code.Meta.UI.Windows.Config
{
	[CreateAssetMenu(menuName = "Headsmasher/Window Config", fileName = "WindowConfig")]
	public class WindowConfig : ScriptableObject
	{
		public WindowId TypeId;
		public GameObject ViewPrefab;
	}
}