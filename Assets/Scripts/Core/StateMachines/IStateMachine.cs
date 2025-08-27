namespace Core.StateMachines
{
    public interface IStateMachine<TState> where TState : IState
    {
        void Enter<T>(params object[] context) where T : IState;
    }
}