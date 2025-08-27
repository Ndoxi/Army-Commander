using Gameplay;
using Gameplay.Stats;
using System;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "EntityFactoryData", menuName = "Scriptable Objects/EntityFactoryData")]
    public class EntityFactoryData : ScriptableObject
    {
        public EntityPrefabData[] prefabDatas => _data;
        [SerializeField] private EntityPrefabData[] _data;

        [Serializable]
        public struct EntityPrefabData
        {
            public EntityType type;
            public Entity prefab;
        }
    }
}