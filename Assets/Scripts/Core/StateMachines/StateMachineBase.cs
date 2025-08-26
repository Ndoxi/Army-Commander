using System;
using System.Collections.Generic;

namespace Core.StateMachines
{
    public abstract class StateMachineBase : IStateMachine
    {
        protected abstract Dictionary<Type, IState> states { get; }
        private IState _current;

        public void Enter<T>(params object[] context) where T : IState
        {
            if (_current != null)
                _current.OnExit();

            _current = GetState<T>();
            _current.OnEnter(context);
        }

        private IState GetState<T>() where T : IState
        {
            return states[typeof(T)];
        }
    }
}