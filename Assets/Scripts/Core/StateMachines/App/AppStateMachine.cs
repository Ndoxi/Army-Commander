using System;
using System.Collections.Generic;
using Zenject;

namespace Core.StateMachines.App
{
    public class AppStateMachine : StateMachineBase<IState>
    {
        protected override Dictionary<Type, IState> states => _states;
        private readonly Dictionary<Type, IState> _states;

        public AppStateMachine(IInstantiator instantiator)
        {
            _states = new Dictionary<Type, IState>() 
            {
                { typeof(InitializationState), instantiator.Instantiate<InitializationState>() },
                { typeof(GameplayState), instantiator.Instantiate<GameplayState>() },
                { typeof(GameEndState), instantiator.Instantiate<GameEndState>() }
            };
        }
    }
}