using Core.Input;
using System;
using Zenject;

namespace Core.StateMachines.App
{
    public class InitializationState : StateBase
    {
        private readonly LazyInject<AppStateMachine> _stateMachineContainer;
        private readonly LazyInject<IInputReader> _inputReaderContainer;

        public InitializationState(LazyInject<AppStateMachine> stateMachineContainer, 
                                   LazyInject<IInputReader> inputReaderContainer)
        {
            _stateMachineContainer = stateMachineContainer;
            _inputReaderContainer = inputReaderContainer;
        }

        public override void OnEnter(params object[] context)
        {
            _inputReaderContainer.Value.enabled = false;
            _stateMachineContainer.Value.Enter<GameplayState>();
        }

        public override void OnExit()
        {
        }
    }
}