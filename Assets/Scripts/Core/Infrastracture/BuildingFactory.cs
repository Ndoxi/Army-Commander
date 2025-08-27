using Data;
using Gameplay;
using UnityEngine;
using Zenject;

namespace Core.Infrastracture
{
    public class BuildingFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly BuildingFactoryData _data;

        public BuildingFactory(IInstantiator instantiator, BuildingFactoryData data)
        {
            _instantiator = instantiator;
            _data = data;
        }

        public Barrack CreateBarrack(Faction faction, Vector3 position, Quaternion rotation)
        {
            return CreateBuilding(_data.barrackPrefab, faction, position, rotation);
        }

        private Barrack CreateBuilding(Barrack prefab, Faction faction, Vector3 position, Quaternion rotation)
        {
            var barrack = _instantiator.InstantiatePrefabForComponent<Barrack>(prefab, position, rotation, null);
            barrack.Init(faction);

            return barrack;
        }
    }
}