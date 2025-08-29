using Core.StateMachines;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using Utils;
using Zenject;

namespace Gameplay.AI
{
    public class DeathState : TickableStateBase
    {
        private const float DestroyDelay = 1f;

        private readonly LazyInject<Unit> _unitContainer;
        private readonly LazyInject<UnitAnimator> _animatorContainer;
        private CancellationTokenSource _cts;

        public DeathState(LazyInject<Unit> unitContainer, 
                          LazyInject<UnitAnimator> animatorContainer)
        {
            _unitContainer = unitContainer;
            _animatorContainer = animatorContainer;
        }

        public override void OnEnter(params object[] context)
        {
            _animatorContainer.Value.Die();

            _cts = new CancellationTokenSource();
            DestroyDelayed(_cts.Token).Forget();
        }

        public override void OnExit()
        {
            _cts.Cancel();
            _cts.Dispose();
        }

        public override void Tick()
        {
        }

        private async UniTaskVoid DestroyDelayed(CancellationToken cancellationToken)
        {
            var canceled = await UniTask.Delay(TimeUtils.ToMilliseconds(DestroyDelay), cancellationToken: cancellationToken)
                                        .SuppressCancellationThrow();

            if (canceled)
                return;

            if (_unitContainer.Value != null)
                Object.Destroy(_unitContainer.Value.gameObject);
        } 
    }
}