namespace Assets.Code.Infrastructure.States.Infrastructure
{
	public interface IPayloadState<TPayload> : IExitableState
	{
		void Enter(TPayload payload);
	}
}