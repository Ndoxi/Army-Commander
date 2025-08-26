using System;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Input
{
    public class JoystickInputReader : MonoBehaviour
    {
        public event Action<Vector2> onMove;
        [SerializeField] private Joystick _joystick;

        private void Update()
        {
            onMove?.Invoke(_joystick.Direction);
        }
    }
}