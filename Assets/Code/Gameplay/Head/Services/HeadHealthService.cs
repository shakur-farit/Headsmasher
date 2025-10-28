using System;
using Assets.Code.Infrastructure.States.GameStates;
using Assets.Code.Infrastructure.States.StateMachine;

namespace Assets.Code.Gameplay.Input
{
	public class HeadHealthService : IHeadHealthService
	{
		private readonly IGameStateMachine _stateMachine;
		public event Action HealthChanged;

		public int CurrentHp { get; private set; }
		public int MaxHp { get; private set; }

		public HeadHealthService(IGameStateMachine stateMachine) => 
			_stateMachine = stateMachine;

		public void SetHp(int currentHp, int maxHp)
		{
			CurrentHp = currentHp;
			MaxHp = maxHp;
		}

		public void DecreaseCurrentHp(int value)
		{
			CurrentHp -= value;

			if (CurrentHp <= 0)
			{
				CurrentHp = 0;
				_stateMachine.Enter<LevelCompleteState>();
			}

			HealthChanged?.Invoke();
		}
	}
}