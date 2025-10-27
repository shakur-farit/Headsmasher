using Assets.Code.Infrastructure.States.Infrastructure;

namespace Assets.Code.Infrastructure.States.Factory
{
	public interface IStateFactory
	{
		T GetState<T>() where T : class, IExitableState;
	}
}