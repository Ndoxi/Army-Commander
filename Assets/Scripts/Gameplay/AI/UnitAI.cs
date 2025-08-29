using Core.StateMachines;
using UnityEngine;
using Zenject;

namespace Gameplay.AI
{
    public class UnitAI : MonoBehaviour
    {
        [SerializeField] private float _updateRate = 0.2f;
        private float _timer;
        private ITickableStateMachine _stateMachine;
        private IEntity _entity;

        [Inject]
        private void Construct(ITickableStateMachine stateMachine, IEntity entity)
        {
            _stateMachine = stateMachine;
            _entity = entity;
        }

        private void Start()
        {
            _stateMachine.Enter<PatrolState>();
        }

        private void OnEnable()
        {
            _entity.onDeath += Die;
        }

        private void OnDisable()
        {
            _entity.onDeath -= Die;
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                UpdateBrain();
                _timer = _updateRate;
            }
        }

        private void UpdateBrain()
        {
            _stateMachine.Tick();
        }

        private void Die(IEntity entity)
        {
            _stateMachine.Enter<DeathState>();
        }
    }
}