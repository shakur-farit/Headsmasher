namespace Assets.Code.Infrastructure.States.Infrastructure
{
	public interface IState : IExitableState
	{
		void Enter();
	}
}