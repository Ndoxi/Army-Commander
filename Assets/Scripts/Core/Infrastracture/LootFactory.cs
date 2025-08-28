using Data;
using Gameplay;
using UnityEngine;
using Zenject;

namespace Core.Infrastracture
{
    public class LootFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly LootFactoryData _data;

        public LootFactory(IInstantiator instantiator, LootFactoryData data)
        {
            _instantiator = instantiator;
            _data = data;
        }

        public void Create(int reward, EntityType allowedEntityType, Vector3 position)
        {
            var loot = _instantiator.InstantiatePrefabForComponent<Loot>(_data.prefab, position, Quaternion.identity, null);
            loot.Init(reward, allowedEntityType);
        }
    }
}