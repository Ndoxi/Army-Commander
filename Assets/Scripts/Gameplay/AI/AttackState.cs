using Core.StateMachines;
using Gameplay.Stats;
using UnityEngine;
using Zenject;

namespace Gameplay.AI
{
    public class AttackState : TickableStateBase
    {
        private readonly LazyInject<ITickableStateMachine> _stateMachineContainer;
        private readonly IEntity _entity;
        private readonly EntityFinder _entityFinder;
        private readonly FactionRelations _relations;
        private float _attackRange;

        public AttackState(LazyInject<ITickableStateMachine> stateMachineContainer,
                           IEntity entity,
                           EntityFinder entityFinder,
                           FactionRelations relations)
        {
            _stateMachineContainer = stateMachineContainer;
            _entity = entity;
            _entityFinder = entityFinder;
            _relations = relations;
        }

        public override void OnEnter(params object[] context)
        {
            Debug.Log("Attack!!!");
            var target = ConvertParam<IEntity>(context[0]);
            _attackRange = _entity.GetStat(StatType.AttackRange).value;
        }

        public override void OnExit() { }

        public override void Tick()
        {
        }
    }
}