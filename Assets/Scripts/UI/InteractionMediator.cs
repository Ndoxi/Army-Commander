using Gameplay;
using System;

namespace UI
{
    public class InteractionMediator : IDisposable
    {
        private readonly InteractionView _view;
        private IInteractable _interactable;

        public InteractionMediator(InteractionView view)
        {
            _view = view;
        }

        public void Init()
        {
            _view.onConfirm += ConfirmInteraction;
        }

        public void Dispose()
        {
            _view.onConfirm -= ConfirmInteraction;
        }

        public void SetTarget(IInteractable interactable)
        {
            _interactable = interactable;

            if (_view == null)
                return;

            if (interactable != null)
                _view.Show();
            else
                _view.Hide();
        }

        private void ConfirmInteraction()
        {
            if (_interactable != null)
            {
                _interactable.Interact();
            }
        }
    }
}