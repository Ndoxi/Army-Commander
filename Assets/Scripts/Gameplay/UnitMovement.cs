using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(Rigidbody))]
    public class UnitMovement : MonoBehaviour
    {
        public Vector2 direction => new Vector2(transform.forward.x, transform.forward.z);
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Move(Vector2 direction)
        {
            _rigidbody.MovePosition(_rigidbody.position + new Vector3(direction.x, 0, direction.y));
        }
    }
}