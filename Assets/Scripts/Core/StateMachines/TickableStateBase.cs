namespace Core.StateMachines
{
    public abstract class TickableStateBase : StateBase, ITickableState
    {
        public abstract void Tick();
    }
}