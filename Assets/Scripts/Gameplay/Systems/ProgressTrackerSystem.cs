using Core.Infrastracture;
using Core.StateMachines.App;

namespace Gameplay.Systems
{
    public class ProgressTrackerSystem
    {
        private readonly AppStateMachine _stateMachine;
        private readonly EntityTracker _entityTracker;
        private Entity _player;
        private Entity _headquarters;

        public ProgressTrackerSystem(AppStateMachine stateMachine, EntityTracker entityTracker)
        {
            _stateMachine = stateMachine;
            _entityTracker = entityTracker;
        }

        public void Init()
        {
            _player = _entityTracker.FindPlayer();
            _headquarters = _entityTracker.FindHeadquarters();

            _player.onDeath += OnPlayerDeath;
            _headquarters.onDeath += OnHeadquartersDeath;
        }

        public void Free()
        {
            _player.onDeath -= OnPlayerDeath;
            _headquarters.onDeath -= OnHeadquartersDeath;

            _player = null;
            _headquarters = null;
        }

        private void OnPlayerDeath(IEntity entity)
        {
            _stateMachine.Enter<GameEndState>(EndGameType.Lose);
        }

        private void OnHeadquartersDeath(IEntity entity)
        {
            _stateMachine.Enter<GameEndState>(EndGameType.Win);
        }
    }
}