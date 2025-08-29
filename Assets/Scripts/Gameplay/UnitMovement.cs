using Gameplay.Stats;
using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(Rigidbody), typeof(IEntity))]
    public class UnitMovement : MonoBehaviour
    {
        public Vector2 direction => new Vector2(transform.forward.x, transform.forward.z);

        [SerializeField] private UnitAnimator _unitAnimator;

        private Rigidbody _rigidbody;
        private IEntity _entity;
        private Vector2 _moveDirection;
        private Stat _moveSpeedStat;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _entity = GetComponent<IEntity>();
        }

        private void Start()
        {
            _moveSpeedStat = _entity.GetStat(StatType.MoveSpeed);
        }

        public void SetDirection(Vector2 direction)
        {
            _moveDirection = direction;
        }

        private void FixedUpdate()
        {
            _unitAnimator.SetSpeed(_moveDirection.magnitude * _moveSpeedStat.value);

            if (_moveDirection == Vector2.zero)
            {
                if (!_rigidbody.isKinematic)
                {
                    _rigidbody.linearVelocity = Vector3.zero;
                    _rigidbody.angularVelocity = Vector3.zero;
                }
                return;
            }

            var dir3D = new Vector3(_moveDirection.x, 0, _moveDirection.y).normalized;
            float speed = _moveSpeedStat.value;

            if (_rigidbody.isKinematic)
                _rigidbody.MovePosition(_rigidbody.position + speed * Time.fixedDeltaTime * dir3D);
            else
                _rigidbody.linearVelocity = speed * dir3D;

            transform.rotation = Quaternion.LookRotation(dir3D, Vector3.up);
            _rigidbody.angularVelocity = Vector3.zero;
        }
    }
}