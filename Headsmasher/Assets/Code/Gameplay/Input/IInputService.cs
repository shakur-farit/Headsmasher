using UnityEngine;

namespace Assets.Code.Gameplay.Input
{
	public interface IInputService
	{
		float GetVerticalAxis();
		float GetHorizontalAxis();
		bool HasAxisInput();

		bool GetLeftMouseButton();
		bool GetLeftMouseButtonDown();
		Vector2 GetScreenMousePosition();
		Vector2 GetWorldMousePosition();
		bool GetLeftMouseButtonUp();
    bool GetJumpButton();
    bool GetJumpButtonDown();
    bool GetJumpButtonUp();
    bool GetRightMouseButton();
    bool GetRightMouseButtonDown();
    bool GetRightMouseButtonUp();
	}
}