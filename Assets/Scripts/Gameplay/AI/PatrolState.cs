using Core.StateMachines;
using Gameplay.Stats;
using UnityEngine;
using Zenject;

namespace Gameplay.AI
{
    public class PatrolState : TickableStateBase
    {
        private readonly LazyInject<ITickableStateMachine> _stateMachineContainer;
        private readonly IEntity _entity;
        private readonly UnitMovement _unitMovement;
        private readonly EntityFinder _entityFinder;
        private readonly FactionRelations _relations;
        private Stat _detectionRadiusStat;
        private Stat _attackRangeStat;

        public PatrolState(LazyInject<ITickableStateMachine> stateMachineContainer,
                           IEntity entity,
                           UnitMovement unitMovement,
                           EntityFinder entityFinder, 
                           FactionRelations relations)
        {
            _stateMachineContainer = stateMachineContainer;
            _entity = entity;
            _unitMovement = unitMovement;
            _entityFinder = entityFinder;
            _relations = relations;
        }

        public override void OnEnter(params object[] context)
        {
            _detectionRadiusStat = _entity.GetStat(StatType.VisionRange);
            _attackRangeStat = _entity.GetStat(StatType.AttackRange);
        }

        public override void OnExit() { }

        public override void Tick()
        {
            var attackTarget = _entityFinder.Find(_entity.position,
                                                  _relations.GetEnemy(_entity.faction),
                                                  _attackRangeStat.value);
            if (attackTarget != null)
            {
                _stateMachineContainer.Value.Enter<AttackState>(attackTarget);
                return;
            }

            var target = _entityFinder.Find(_entity.position,
                                            _relations.GetEnemy(_entity.faction),
                                            _detectionRadiusStat.value);

            _unitMovement.Move(GetDirection(target));
        }

        private Vector2 GetDirection(IEntity target)
        {
            if (target == null)
                return _unitMovement.direction;
            var direction = target.position - _entity.position;
            return new Vector2(direction.x, direction.z).normalized;
        }
    }
}