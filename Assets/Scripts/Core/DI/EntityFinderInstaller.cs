using Gameplay;
using Zenject;

namespace Core.DI
{
    public class EntityFinderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<EntityFinder>()
                     .To<EntityFinder>()
                     .AsSingle();
        }
    }
}