using Core.Infrastracture;
using Data;
using UnityEngine;
using Zenject;

namespace Core.DI
{
    public class LevelBuilderInstaller : MonoInstaller
    {
        [SerializeField] private LevelBuilderData _data;

        public override void InstallBindings()
        {
            Container.Bind<LevelBuilder>()
                     .To<LevelBuilder>()
                     .AsSingle()
                     .WithArguments(_data);
        }
    }
}