using UnityEngine;

namespace Gameplay
{
    public interface IInteractable
    {
        Vector3 position { get; }
        Faction faction { get; }
        void Interact();
        void CompleteInteraction();
    }
}