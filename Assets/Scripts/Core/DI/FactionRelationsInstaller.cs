using Data;
using Gameplay;
using UnityEngine;
using Zenject;

namespace Core.DI
{
    public class FactionRelationsInstaller : MonoInstaller
    {
        [SerializeField] private FactionRelationsData _data;

        public override void InstallBindings()
        {
            Container.Bind<FactionRelations>()
                     .To<FactionRelations>()
                     .AsSingle()
                     .WithArguments(_data);
        }
    }
}