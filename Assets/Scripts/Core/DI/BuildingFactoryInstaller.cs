using Core.Infrastracture;
using Zenject;

namespace Core.DI
{
    public class BuildingFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BuildingFactory>()
                     .To<BuildingFactory>()
                     .AsSingle();
        }
    }
}