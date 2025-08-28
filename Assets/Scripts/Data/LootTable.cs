using Gameplay;
using System;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "LootTable", menuName = "Scriptable Objects/LootTable")]
    public class LootTable : ScriptableObject
    {
        public LootData[] loot => _data;
        [SerializeField] private LootData[] _data;

        [Serializable]
        public struct LootData
        {
            public EntityType dropedBy;
            public Faction faction;
            public int reward;
            public EntityType allowedEntityType;
        }
    }
}