using Core.StateMachines;
using Cysharp.Threading.Tasks;
using Gameplay.Stats;
using Gameplay.Systems;
using System.Threading;
using UnityEngine;
using Utils;
using Zenject;

namespace Gameplay.AI
{
    public class AttackState : TickableStateBase
    {
        private readonly LazyInject<ITickableStateMachine> _stateMachineContainer;
        private readonly IEntity _entity;
        private readonly EntityFinder _entityFinder;
        private readonly FactionRelations _relations;
        private readonly DamageSystem _damageSystem;
        private Stat _attackRangeStat;
        private Stat _attackDamageStat;
        private Stat _attackSpeedStat;
        private CancellationTokenSource _cts;
        private IEntity _currentTarget;

        public AttackState(LazyInject<ITickableStateMachine> stateMachineContainer,
                           IEntity entity,
                           EntityFinder entityFinder,
                           FactionRelations relations,
                           DamageSystem damageSystem)
        {
            _stateMachineContainer = stateMachineContainer;
            _entity = entity;
            _entityFinder = entityFinder;
            _relations = relations;
            _damageSystem = damageSystem;
        }

        public override void OnEnter(params object[] context)
        {
            _currentTarget = ConvertParam<IEntity>(context[0]);

            _attackRangeStat = _entity.GetStat(StatType.AttackRange);
            _attackDamageStat = _entity.GetStat(StatType.AttackDamage);
            _attackSpeedStat = _entity.GetStat(StatType.AttackSpeed);

            _cts = new CancellationTokenSource();
            RunAttackLoop(_cts.Token).Forget();
        }

        public override void OnExit() 
        {
            _currentTarget = null;
            _cts.Cancel();
            _cts.Dispose();
        }

        public override void Tick()
        {
            _currentTarget = _entityFinder.Find(_entity.position, _relations.GetEnemy(_entity.faction), _attackRangeStat.value);
            if (_currentTarget == null)
                _stateMachineContainer.Value.Enter<PatrolState>();
        }

        private async UniTaskVoid RunAttackLoop(CancellationToken cancellationToken)
        {
            while (_currentTarget != null)
            {
                _damageSystem.ApplyDamage(_currentTarget, _attackDamageStat.value);

                bool canceled = await UniTask.Delay(TimeUtils.ToMilliseconds(_attackSpeedStat.value), cancellationToken: cancellationToken)
                                             .SuppressCancellationThrow();

                if (canceled)
                    return;
            }
        }
    }
}