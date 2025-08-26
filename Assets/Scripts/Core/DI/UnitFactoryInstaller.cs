using Core.Infrastracture;
using Data;
using UnityEngine;
using Zenject;

namespace Core.DI
{
    public class UnitFactoryInstaller : MonoInstaller
    {
        [SerializeField] private UnitFactoryData _data;

        public override void InstallBindings()
        {
            Container.Bind<UnitFactory>()
                     .To<UnitFactory>()
                     .AsTransient()
                     .WithArguments(_data);
        }
    }
}