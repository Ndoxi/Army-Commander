using Core.StateMachines;
using UnityEngine;
using Zenject;

namespace Gameplay.AI
{
    public class UnitAI : MonoBehaviour
    {
        [SerializeField] private float _updateRate = 0.2f;
        [SerializeField] private float _detectionRadius;
        [SerializeField] private float _attackRange;
        private float _timer;
        private ITickableStateMachine _stateMachine;

        [Inject]
        private void Construct(ITickableStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void Awake()
        {
            _stateMachine.Enter<PatrolState>(_detectionRadius, _attackRange);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _detectionRadius);
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
    }
}