using System;
using System.Collections.Generic;
using UI;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    [RequireComponent(typeof(Collider))]
    public class Interactor : MonoBehaviour
    {
        private Collider _collider;
        private readonly List<IInteractable> _interactables = new List<IInteractable>();
        private IInteractable _target;
        private InteractionMediator _mediator;

        [Inject]
        private void Construct(InteractionMediator mediator)
        {
            _mediator = mediator;
        }

        private void Awake()
        {
            _collider = GetComponent<Collider>();
        }

        private void OnEnable()
        {
            SetSearchingState();
        }

        private void OnDisable()
        {
            _mediator.SetTarget(null);
            FreeTarget();
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
        
        private void SetSearchingState()
        {
            SetState(State.Searching);
        }

        private void SetInteractingState()
        {
            SetState(State.Interacting);
        }

        private void SetState(State state)
        {
            switch (state)
            {
                case State.Searching:
                    UpdateTarget();
                    _collider.enabled = true;
                    break;

                case State.Interacting:
                    _collider.enabled = false;
                    _mediator.SetTarget(null);
                    FreeTarget();
                    break;
            }
        }

        private void FreeTarget()
        {
            if (_target != null)
            {
                _target.onInteractionBegin += SetInteractingState;
                _target.onInteractionEnd += SetSearchingState;
            }
            _target = null;
        }

        private void UpdateTarget()
        {
            var newTarget = GetClosestInteractable();
            if (newTarget != _target)
            {
                FreeTarget();

                _target = newTarget;
                if (_target != null)
                {
                    _target.onInteractionBegin += SetInteractingState;
                    _target.onInteractionEnd += SetSearchingState;
                }

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


        private enum State
        {
            Searching,
            Interacting
        }
    }
}