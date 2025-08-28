using Core.StateMachines;
using System;
using System.Collections.Generic;
using Zenject;

namespace Gameplay.AI
{
    public class UnitAiStateMachine : TickableStateMachineBase
    {
        protected override Dictionary<Type, ITickableState> states => _states;
        private readonly Dictionary<Type, ITickableState> _states;

        public UnitAiStateMachine(IInstantiator instantiator)
        {
            _states = new Dictionary<Type, ITickableState>()
            {
                { typeof(PatrolState), instantiator.Instantiate<PatrolState>() },
                { typeof(AttackState), instantiator.Instantiate<AttackState>() },
                { typeof(DeathState), instantiator.Instantiate<DeathState>() }
            };
        }

        public override void Tick()
        {
            _current?.Tick();
        }
    }
}