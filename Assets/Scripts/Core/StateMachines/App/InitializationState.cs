using Core.Input;
using System;
using UI;
using Zenject;

namespace Core.StateMachines.App
{
    public class InitializationState : StateBase
    {
        private readonly LazyInject<AppStateMachine> _stateMachineContainer;
        private readonly LazyInject<IInputReader> _inputReaderContainer;
        private readonly LazyInject<InteractionMediator> _interactionMediatorContainer;
        private readonly LazyInject<UpgradesMediator> _upgradesMediatorContainer;

        public InitializationState(LazyInject<AppStateMachine> stateMachineContainer, 
                                   LazyInject<IInputReader> inputReaderContainer,
                                   LazyInject<InteractionMediator> interactionMediatorContainer,
                                   LazyInject<UpgradesMediator> upgradesMediatorContainer)
        {
            _stateMachineContainer = stateMachineContainer;
            _inputReaderContainer = inputReaderContainer;
            _interactionMediatorContainer = interactionMediatorContainer;
            _upgradesMediatorContainer = upgradesMediatorContainer;
        }

        public override void OnEnter(params object[] context)
        {
            _inputReaderContainer.Value.enabled = false;
            _interactionMediatorContainer.Value.Init();
            _upgradesMediatorContainer.Value.Init();

            _stateMachineContainer.Value.Enter<GameplayState>();
        }

        public override void OnExit()
        {
        }
    }
}