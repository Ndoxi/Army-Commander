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

        [Inject]
        private void Construct(ITickableStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void Start()
        {
            _stateMachine.Enter<PatrolState>();
        }

        private void OnDisable()
        {
            _stateMachine.Enter<DeathState>();
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