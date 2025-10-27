using Assets.Code.Infrastructure.States.Infrastructure;

namespace Assets.Code.Infrastructure.States.StateMachine
{
	public interface IGameStateMachine
	{
		void Tick();
		void Enter<TState>() where TState : class, IState;
		void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
	}
}