using UnityEngine;

namespace Gameplay
{
    public class UnitAnimator : MonoBehaviour
    {
        private readonly int SpeedHash = Animator.StringToHash("Speed");
        [SerializeField] private Animator _animator;

        public void SetSpeed(float value)
        {
            _animator.SetFloat(SpeedHash, value);
        }
    }
}