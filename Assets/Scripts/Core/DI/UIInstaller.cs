using UnityEngine;
using Zenject;
using UI;
using System;

namespace Core.DI
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private InteractionView _interactionView;
        [SerializeField] private UpgradesView _upgradesView;

        public override void InstallBindings()
        {
            Container.Bind(typeof(InteractionMediator), typeof(IDisposable))
                     .To<InteractionMediator>()
                     .AsSingle()
                     .WithArguments(_interactionView);            
            
            Container.Bind(typeof(UpgradesMediator), typeof(IDisposable))
                     .To<UpgradesMediator>()
                     .AsSingle()
                     .WithArguments(_upgradesView);
        }
    }
}