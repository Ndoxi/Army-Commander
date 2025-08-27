using Core.StateMachines;
using Core.StateMachines.App;
using Zenject;

namespace Core.DI
{
    public class AppStateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<AppStateMachine>()
                     .To<AppStateMachine>()
                     .AsSingle();
        }
    }
}