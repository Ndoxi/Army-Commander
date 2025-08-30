using System;
using UI;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    [RequireComponent(typeof(Barrack))]
    public class BarrackInteractable : MonoBehaviour, IInteractable
    {
        public event Action onInteractionBegin;
        public event Action onInteractionEnd;
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
            _upgradesMediator.BeginUpgradeFlow(_barrack, () => onInteractionEnd?.Invoke());
            onInteractionBegin?.Invoke();
        }
    }
}