using Core.Infrastracture;
using Zenject;

namespace Core.DI
{
    public class StatsFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<StatFactory>()
                     .To<StatFactory>()
                     .AsSingle();
        }
    }
}