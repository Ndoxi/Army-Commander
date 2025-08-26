namespace Core.StateMachines
{
    public interface IState
    {
        void OnEnter(params object[] context);
        void OnExit();
    }
}