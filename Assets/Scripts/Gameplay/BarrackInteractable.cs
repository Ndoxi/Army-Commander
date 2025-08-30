using UI;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    [RequireComponent(typeof(Barrack))]
    public class BarrackInteractable : MonoBehaviour, IInteractable
    {
        public Vector3 position => _barrack.position;

        private Barrack _barrack;
        private UpgradesMediator _upgradesMediator;

        [Inject]
        private void Construct(UpgradesMediator upgradesMediator)
        {
            _upgradesMediator = upgradesMediator;
        }

        private void Awake()
        {
            _barrack = GetComponent<Barrack>();
        }

        public void Interact()
        {
            _upgradesMediator.SetTarget(_barrack);
        }

        public void CompleteInteraction()
        {
            _upgradesMediator.SetTarget(null);
        }
    }
}