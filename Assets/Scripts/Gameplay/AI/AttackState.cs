using Core.StateMachines;
using UnityEngine;

namespace Gameplay.AI
{
    public class AttackState : TickableStateBase
    {
        public override void OnEnter(params object[] context)
        {
            Debug.Log("Attack!!!");
        }

        public override void OnExit()
        {
        }

        public override void Tick()
        {
        }
    }
}