using Gameplay;
using System;
using UI;
using Zenject;

namespace Core.StateMachines.App
{
    public class GameEndState : StateBase
    {
        private readonly LazyInject<EndGameMediator> _endGameMediatorContainer;

        public GameEndState(LazyInject<EndGameMediator> endGameMediatorContainer)
        {
            _endGameMediatorContainer = endGameMediatorContainer;
        }

        public override void OnEnter(params object[] context)
        {
            var endGameType = ConvertParam<EndGameType>(context[0]);
            _endGameMediatorContainer.Value.OnEndGame(endGameType);
        }

        public override void OnExit()
        {
            _endGameMediatorContainer.Value.OnEndGameExit();
        }
    }
}