using System;
using System.Collections.Generic;
using UI;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Interactor : MonoBehaviour
    {
        private readonly List<IInteractable> _interactables = new List<IInteractable>();
        private IInteractable _target;
        private InteractionMediator _mediator;

        [Inject]
        private void Construct(InteractionMediator mediator)
        {
            _mediator = mediator;
        }

        private void OnDisable()
        {
            _mediator.SetTarget(null);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody != null 
                && other.attachedRigidbody.TryGetComponent<IInteractable>(out var interactable))
            {
                if (!_interactables.Contains(interactable))
                {
                    _interactables.Add(interactable);
                    UpdateTarget();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.attachedRigidbody != null
                && other.attachedRigidbody.TryGetComponent<IInteractable>(out var interactable))
            {
                _interactables.Remove(interactable);
                UpdateTarget();
            }
        }

        private void UpdateTarget()
        {
            var newTarget = GetClosestInteractable();
            if (newTarget != _target)
            {
                if (_target != null)
                    _target.CompleteInteraction();

                _target = newTarget;
                _mediator.SetTarget(newTarget);
            }
        }

        private IInteractable GetClosestInteractable()
        {
            if (_interactables.Count == 0)
                return null;

            IInteractable closest = null;
            float minDist = float.MaxValue;
            Vector3 myPos = transform.position;

            foreach (var interactable in _interactables)
            {
                float dist = Vector3.SqrMagnitude(interactable.position - myPos);

                if (dist < minDist)
                {
                    minDist = dist;
                    closest = interactable;
                }
            }

            return closest;
        }
    }
}