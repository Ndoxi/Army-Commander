using Core.Input;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    [RequireComponent(typeof(UnitMovement))]
    public class UnitInputReceiver : MonoBehaviour
    {
        private UnitMovement _unitMovement;
        private IInputReader _inputReader;

        [Inject]
        private void Construct(IInputReader inputReader)
        {
            _inputReader = inputReader;
        }

        private void Awake()
        {
            _unitMovement = GetComponent<UnitMovement>();
        }

        private void OnEnable()
        {
            _inputReader.onMoveAction += Move;
        }

        private void OnDisable()
        {
            _inputReader.onMoveAction -= Move;
        }

        private void Move(Vector2 direction)
        {
            _unitMovement.Move(direction);
        }
    }
}