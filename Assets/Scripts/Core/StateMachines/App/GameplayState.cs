using Core.Infrastracture;
using Core.Input;
using System;
using Zenject;

namespace Core.StateMachines.App
{
    public class GameplayState : StateBase
    {
        private readonly LazyInject<LevelBuilder> _levelBuilderContainer;
        private readonly LazyInject<IInputReader> _inputReaderContainer;

        public GameplayState(LazyInject<LevelBuilder> levelBuilderContainer, 
                             LazyInject<IInputReader> inputReaderContainer)
        {
            _levelBuilderContainer = levelBuilderContainer;
            _inputReaderContainer = inputReaderContainer;
        }

        public override void OnEnter(params object[] context)
        {
            _levelBuilderContainer.Value.CreateLevel();
            _inputReaderContainer.Value.enabled = true;
        }

        public override void OnExit()
        {
            _inputReaderContainer.Value.enabled = false;
            _levelBuilderContainer.Value.DestroyLevel();
        }
    }
}