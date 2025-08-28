using Core.StateMachines.App;
using Gameplay;
using System;

namespace UI
{
    public class EndGameMediator : IDisposable
    {
        private readonly EndGameView _view;
        private readonly AppStateMachine _stateMachine;

        public EndGameMediator(EndGameView view, AppStateMachine stateMachine)
        {
            _view = view;
            _stateMachine = stateMachine;
        }

        public void Init()
        {
            _view.onRestart += Restart;
        }

        public void Dispose()
        {
            _view.onRestart -= Restart;
        }

        public void OnEndGame(EndGameType endGameType)
        {
            _view.Show(endGameType);
        }

        public void OnEndGameExit()
        {
            _view.Hide();
        }

        private void Restart()
        {
            _stateMachine.Enter<GameplayState>();
        }
    }
}