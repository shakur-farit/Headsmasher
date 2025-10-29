using System;
using Assets.Code.Infrastructure.States.GameStates;
using Assets.Code.Infrastructure.States.StateMachine;

namespace Assets.Code.Gameplay.Input
{
  public class HeadHealthService : IHeadHealthService
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly IHeadDeathService _death;
    public event Action HealthChanged;

    public float CurrentHp { get; private set; }
    public float MaxHp { get; private set; }

    public HeadHealthService(IGameStateMachine stateMachine, IHeadDeathService death)
    {
      _stateMachine = stateMachine;
      _death = death;
    }

    public void SetHp(float currentHp, float maxHp)
    {
      CurrentHp = currentHp;
      MaxHp = maxHp;
    }

    public void DecreaseCurrentHp(float value)
    {
      CurrentHp -= value;

      if (CurrentHp <= 0)
      {
        CurrentHp = 0;
        _death.Die();
        _stateMachine.Enter<LevelCompleteState>();
      }

      HealthChanged?.Invoke();
    }
  }
}