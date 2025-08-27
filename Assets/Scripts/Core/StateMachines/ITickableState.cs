namespace Core.StateMachines
{
    public interface ITickableState : IState
    {
        void Tick();
    }
}