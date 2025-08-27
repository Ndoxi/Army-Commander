namespace Core.StateMachines
{
    public interface ITickableStateMachine : IStateMachine<ITickableState>
    {
        void Tick();
    }
}