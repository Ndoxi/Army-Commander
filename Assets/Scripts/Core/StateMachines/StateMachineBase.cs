using System;
using System.Collections.Generic;

namespace Core.StateMachines
{
    public abstract class StateMachineBase<TState> : IStateMachine<TState> where TState : IState
    {
        protected abstract Dictionary<Type, TState> states { get; }
        protected TState _current;

        public void Enter<T>(params object[] context) where T : IState
        {
            if (_current != null)
                _current.OnExit();

            _current = GetState<T>();
            _current.OnEnter(context);
        }

        private TState GetState<T>() where T : IState
        {
            return states[typeof(T)];
        }
    }
}