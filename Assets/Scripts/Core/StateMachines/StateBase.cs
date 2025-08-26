using System;

namespace Core.StateMachines
{
    public abstract class StateBase : IState
    {
        public abstract void OnEnter(params object[] context);
        public abstract void OnExit();

        protected T ConvertParam<T>(object param)
        {
            if (param is T value)
                return value;

            try
            {
                return (T)Convert.ChangeType(param, typeof(T));
            }
            catch (Exception ex)
            {
                throw new InvalidCastException($"Cannot convert param of type {param?.GetType()} to {typeof(T)}", ex);
            }
        }
    }
}