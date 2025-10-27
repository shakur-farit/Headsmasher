using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace Assets.Code.Gameplay.Input
{
	public class StandaloneInputService : IInputService
	{
		private UnityEngine.Camera _mainCamera;
		private Vector3 _screenPosition;

		public UnityEngine.Camera CameraMain
		{
			get
			{
				if (_mainCamera == null && UnityEngine.Camera.main != null)
					_mainCamera = UnityEngine.Camera.main;

				return _mainCamera;
			}
		}

		public Vector2 GetScreenMousePosition() =>
			CameraMain ? UnityEngine.Input.mousePosition : new Vector2();

		public Vector2 GetWorldMousePosition()
		{
			if (CameraMain == null)
				return Vector2.zero;

			_screenPosition.x = UnityEngine.Input.mousePosition.x;
			_screenPosition.y = UnityEngine.Input.mousePosition.y;
			return CameraMain.ScreenToWorldPoint(_screenPosition);
		}

		public bool HasAxisInput() => GetHorizontalAxis() != 0 || GetVerticalAxis() != 0;

		public float GetVerticalAxis() => UnityEngine.Input.GetAxisRaw("Vertical");
		public float GetHorizontalAxis() => UnityEngine.Input.GetAxisRaw("Horizontal");


		public bool GetLeftMouseButton() =>
			UnityEngine.Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject();

		public bool GetLeftMouseButtonDown() =>
			UnityEngine.Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject();

		public bool GetLeftMouseButtonUp() =>
      UnityEngine.Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject();

		public bool GetRightMouseButton() =>
			UnityEngine.Input.GetMouseButton(1) && !EventSystem.current.IsPointerOverGameObject();

		public bool GetRightMouseButtonDown() =>
			UnityEngine.Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject();

		public bool GetRightMouseButtonUp() =>
			UnityEngine.Input.GetMouseButtonUp(1) && !EventSystem.current.IsPointerOverGameObject();


		public bool GetJumpButton() =>
      UnityEngine.Input.GetKey(KeyCode.Space);

    public bool GetJumpButtonDown() =>
      UnityEngine.Input.GetKeyDown(KeyCode.Space);

    public bool GetJumpButtonUp() =>
      UnityEngine.Input.GetKeyUp(KeyCode.Space);
  }
}