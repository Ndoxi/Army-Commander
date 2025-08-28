using Core.DI;
using Data;
using Gameplay;
using Gameplay.Stats;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Core.Infrastracture
{
    public class EntityFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly StatFactory _statFactory;
        private readonly EntityFactoryData _data;
        private readonly EntitiesStatsConfig _statsConfig;

        public EntityFactory(IInstantiator instantiator,
                             StatFactory statFactory,
                             EntityFactoryData data,
                             EntitiesStatsConfig statsConfig) 
        {
            _instantiator = instantiator;
            _statFactory = statFactory;
            _data = data;
            _statsConfig = statsConfig;
        }

        public Entity Create(EntityType entityType, Faction faction, Vector3 position, Quaternion rotation)
        {
            var prefab = GetPrefab(entityType);
            var statsConfig = GetStatsConfig(entityType).ToDictionary(c => c.type, c => _statFactory.Create(c.baseValue));

            var entity = _instantiator.InstantiatePrefabForComponent<Entity>(prefab,
                                                                             position,
                                                                             rotation,
                                                                             null);
            entity.Init(entityType, faction, statsConfig);

            return entity;
        }

        private Entity GetPrefab(EntityType entityType)
        {
            return _data.prefabDatas.First(data => data.type == entityType).prefab;
        }

        private EntitiesStatsConfig.StatsConfig[] GetStatsConfig(EntityType entityType)
        {
            return _statsConfig.data.First(data => data.type == entityType).stats;
        }
    }
}