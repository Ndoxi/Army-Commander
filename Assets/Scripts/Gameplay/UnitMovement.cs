using Gameplay.Stats;
using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(Rigidbody), typeof(IEntity))]
    public class UnitMovement : MonoBehaviour
    {
        public Vector2 direction => new Vector2(transform.forward.x, transform.forward.z);

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

        private void Update()
        {
            var dir3D = new Vector3(_moveDirection.x, 0, _moveDirection.y);
            _rigidbody.MovePosition(_rigidbody.position + _moveSpeedStat.value * Time.deltaTime * dir3D);
        }
    }
}