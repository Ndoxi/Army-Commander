using DG.Tweening;
using UnityEngine;

namespace Gameplay
{
    public class LootAnimation : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float jumpHeight = 0.25f;
        [SerializeField] private float jumpDuration = 0.5f;
        [SerializeField] private float rotationSpeed = 180f;

        private void Start()
        {
            Animate();
        }

        public void Animate()
        {
            _target.DOMoveY(_target.position.y + jumpHeight, jumpDuration)
                .SetEase(Ease.OutQuad)
                .SetLoops(2, LoopType.Yoyo);

            _target.DORotate(new Vector3(0, 360, 0), 1f, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Restart);
        }
    }
}