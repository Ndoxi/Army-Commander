using Core.Infrastracture;
using Data;
using UnityEngine;
using Zenject;

namespace Core.DI
{
    public class LootFactoryInstaller : MonoInstaller
    {
        [SerializeField] private LootFactoryData _factoryData;

        public override void InstallBindings()
        {
            Container.Bind<LootFactory>()
                     .To<LootFactory>()
                     .AsSingle()
                     .WithArguments(_factoryData);
        }
    }
}