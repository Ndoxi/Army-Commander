using Core.Infrastracture;
using Data;
using UnityEngine;
using Zenject;

namespace Core.DI
{
    public class EntityFactoryInstaller : MonoInstaller
    {
        [SerializeField] private EntityFactoryData _data;
        [SerializeField] private EntitiesStatsConfig _statsConfig;

        public override void InstallBindings()
        {
            Container.Bind<EntityFactory>()
                     .To<EntityFactory>()
                     .AsSingle()
                     .WithArguments(_data, _statsConfig);
        }
    }
}