using Core.Infrastracture;
using Data;
using UnityEngine;
using Zenject;

namespace Core.DI
{
    public class BuildingFactoryInstaller : MonoInstaller
    {
        [SerializeField] private BuildingFactoryData _data;

        public override void InstallBindings()
        {
            Container.Bind<BuildingFactory>()
                     .To<BuildingFactory>()
                     .AsSingle()
                     .WithArguments(_data);
        }
    }
}