using System;
using UnityEngine;

namespace Gameplay
{
    public interface IInteractable
    {
        event Action onInteractionBegin;
        event Action onInteractionEnd;
        Vector3 position { get; }
        void Interact();
    }
}