using System;

namespace Assets.Code.Gameplay.Input
{
  public class HeadDeathService : IHeadDeathService
  {
    public event Action Dead;

    public void Die() => 
      Dead?.Invoke();
  }
}