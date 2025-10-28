using System;

namespace Assets.Code.Gameplay.Input
{
	public interface IHeadHealthService
	{
		event Action HealthChanged;
		int CurrentHp { get; }
		int MaxHp { get; }
		void SetHp(int currentHp, int maxHp);
		void DecreaseCurrentHp(int value);
	}
}