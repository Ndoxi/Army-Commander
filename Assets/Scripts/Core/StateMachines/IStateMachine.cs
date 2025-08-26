namespace Core.StateMachines
{
    public interface IStateMachine
    {
        void Enter<T>(params object[] context) where T : IState;
    }
}