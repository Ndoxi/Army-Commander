using System;
using UnityEngine;

namespace Core.Input
{
    public interface IInputReader
    {
        event Action<Vector2> onMoveAction;
        bool enabled { get; set; }
    }
}