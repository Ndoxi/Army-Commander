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
        public EntityPrefabDecoratorData[] decoratorData => _decoratorData;

        [SerializeField] private EntityPrefabData[] _data;
        [SerializeField] private EntityPrefabDecoratorData[] _decoratorData;


        [Serializable]
        public struct EntityPrefabData
        {
            public EntityType type;
            public Entity prefab;
        }

        [Serializable]
        public struct EntityPrefabDecoratorData
        {
            public EntityType type;
            public Faction faction;
            public SerializedType[] components;
        }
    }
}