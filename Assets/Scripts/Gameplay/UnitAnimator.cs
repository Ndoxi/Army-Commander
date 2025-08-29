using UnityEngine;

namespace Gameplay
{
    public class UnitAnimator : MonoBehaviour
    {
        private readonly int SpeedHash = Animator.StringToHash("Speed");
        private readonly int DieHash = Animator.StringToHash("Die");
        private readonly int AttackHash = Animator.StringToHash("Attack");

        [SerializeField] private Animator _animator;

        public void SetSpeed(float value)
        {
            if (_animator != null)
                _animator.SetFloat(SpeedHash, value);
        }

        public void Die()
        {
            if (_animator != null)
                _animator.SetTrigger(DieHash);
        }

        public void Attack()
        {
            if (_animator != null)
                _animator.SetTrigger(AttackHash);
        }
    }
}