using UnityEngine;

namespace Gameplay
{
    public interface IInteractable
    {
        Vector3 position { get; }
        void Interact();
        void CompleteInteraction();
    }
}