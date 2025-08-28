using Core.Infrastracture;
using Core.Input;
using Gameplay.Systems;
using System;
using Zenject;

namespace Core.StateMachines.App
{
    public class GameplayState : StateBase
    {
        private readonly LazyInject<LevelBuilder> _levelBuilderContainer;
        private readonly LazyInject<IInputReader> _inputReaderContainer;
        private readonly LazyInject<ProgressTrackerSystem> _progressTrackerSystemContainer;

        public GameplayState(LazyInject<LevelBuilder> levelBuilderContainer, 
                             LazyInject<IInputReader> inputReaderContainer,
                             LazyInject<ProgressTrackerSystem> progressTrackerSystemContainer)
        {
            _levelBuilderContainer = levelBuilderContainer;
            _inputReaderContainer = inputReaderContainer;
            _progressTrackerSystemContainer = progressTrackerSystemContainer;
        }

        public override void OnEnter(params object[] context)
        {
            _levelBuilderContainer.Value.CreateLevel();
            _progressTrackerSystemContainer.Value.Init();
            _inputReaderContainer.Value.enabled = true;
        }

        public override void OnExit()
        {
            _inputReaderContainer.Value.enabled = false;
            _levelBuilderContainer.Value.DestroyLevel();
            _progressTrackerSystemContainer.Value.Free();
        }
    }
}