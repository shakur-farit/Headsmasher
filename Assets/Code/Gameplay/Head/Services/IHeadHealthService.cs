using System;

namespace Assets.Code.Gameplay.Input
{
	public interface IHeadHealthService
	{
		event Action HealthChanged;
		float CurrentHp { get; }
		float MaxHp { get; }
		void SetHp(float currentHp, float maxHp);
		void DecreaseCurrentHp(float value);
	}
}