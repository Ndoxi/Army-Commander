using Data;
using Gameplay;
using UnityEngine;
using Zenject;

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

        public Unit CreatePlayer(Vector3 position)
        {
            return CreateUnit(_data.playerPrefab, position);
        }

        private Unit CreateUnit(Unit prefab, Vector3 position)
        {
            return _instantiator.InstantiatePrefabForComponent<Unit>(prefab, position, Quaternion.identity, null);
        }
    }
}