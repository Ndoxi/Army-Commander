using Data;
using Gameplay;
using UnityEngine;
using Zenject;
using Gameplay;

namespace Core.Infrastracture
{
    public class UnitFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly UnitFactoryData _data;

        public UnitFactory(IInstantiator instantiator, UnitFactoryData data) 
        {
            _instantiator = instantiator;
            _data = data;
        }

        public Unit CreatePlayer(Faction faction, Vector3 position)
        {
            return CreateUnitInternal(_data.playerPrefab, faction, position, Quaternion.identity);
        }

        public Unit CreateUnit(Faction faction, Vector3 position, Quaternion rotation)
        {
            return CreateUnitInternal(_data.unitPrefab, faction, position, rotation);
        }

        private Unit CreateUnitInternal(Unit prefab, Faction faction, Vector3 position, Quaternion rotation)
        {
            var unit = _instantiator.InstantiatePrefabForComponent<Unit>(prefab, position, rotation, null);
            unit.faction = faction;

            return unit;
        }
    }
}