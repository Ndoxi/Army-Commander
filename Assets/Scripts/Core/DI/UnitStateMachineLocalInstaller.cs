using Core.StateMachines;
using Gameplay.AI;
using Zenject;

namespace Core.DI
{
    public class UnitStateMachineLocalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PatrolState>()
                     .To<PatrolState>()
                     .AsTransient();

            Container.Bind<AttackState>()
                     .To<AttackState>()
                     .AsTransient();

            Container.Bind<ITickableStateMachine>()
                     .To<UnitAiStateMachine>()
                     .AsSingle();
        }
    }
}