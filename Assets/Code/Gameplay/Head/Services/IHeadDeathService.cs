using System;

namespace Assets.Code.Gameplay.Input
{
  public interface IHeadDeathService
  {
    event Action Dead;
    void Die();
  }
}