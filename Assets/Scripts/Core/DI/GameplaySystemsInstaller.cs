using Core.Infrastracture;
using Data;
using Gameplay.Systems;
using System;
using UnityEngine;
using Zenject;

namespace Core.DI
{
    public class GameplaySystemsInstaller : MonoInstaller
    {
        [SerializeField] private LootTable _lootTable;
        [SerializeField] private UpgradeConfig _upgradeConfig;

        public override void InstallBindings()
        {
            Container.Bind<EntityTracker>()
                     .To<EntityTracker>()
                     .AsSingle();            
            
            Container.Bind<LootTracker>()
                     .To<LootTracker>()
                     .AsSingle();

            Container.Bind<ProgressTrackerSystem>()
                     .To<ProgressTrackerSystem>()
                     .AsSingle();

            Container.Bind<UnitHudTracker>()
                     .To<UnitHudTracker>()
                     .AsSingle();

            Container.Bind<CurrencySystem>()
                     .To<CurrencySystem>()
                     .AsSingle();            
            
            Container.Bind<UpgradeSystem>()
                     .To<UpgradeSystem>()
                     .AsSingle()
                     .WithArguments(_upgradeConfig);

            Container.Bind(typeof(LootDropSystem), typeof(IDisposable))
                     .To<LootDropSystem>()
                     .AsSingle()
                     .WithArguments(_lootTable);

            Container.Bind<EntityFinder>()
                     .To<EntityFinder>()
                     .AsSingle();

            Container.Bind<DamageSystem>()
                     .To<DamageSystem>()
                     .AsSingle();            
        }
    }
}