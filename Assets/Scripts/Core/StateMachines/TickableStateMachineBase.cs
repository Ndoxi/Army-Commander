namespace Core.StateMachines
{
    public abstract class TickableStateMachineBase : StateMachineBase<ITickableState>, ITickableStateMachine
    {
        public abstract void Tick();
    }
}