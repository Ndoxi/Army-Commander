using System;
using UnityEngine;

namespace Core.Input
{
    public class JoystickInputMediator : IInputReader, IDisposable
    {
        public event Action<Vector2> onMoveAction;

        private readonly JoystickInputReader _inputReader;

        public bool enabled
        { 
            get => _inputReader.gameObject.activeInHierarchy; 
            set => _inputReader.gameObject.SetActive(value); 
        }

        public JoystickInputMediator(JoystickInputReader inputReader)
        {
            _inputReader = inputReader;
        }

        public void Init()
        {
            _inputReader.onMove += OnMove;
        }

        public void Dispose()
        {
            _inputReader.onMove -= OnMove;
        }

        private void OnMove(Vector2 direction)
        {
            onMoveAction?.Invoke(direction);
        }
    }
}