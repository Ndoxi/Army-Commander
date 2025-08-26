using Core.StateMachines;
using Core.StateMachines.App;
using UnityEngine;
using Zenject;

namespace Core.Infrastracture
{
    public class AppStarter : MonoBehaviour
    {
        private AppStateMachine _stateMachine;

        [Inject]
        private void Construct(AppStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void Awake()
        {
            _stateMachine.Enter<InitializationState>();
        }
    }
}