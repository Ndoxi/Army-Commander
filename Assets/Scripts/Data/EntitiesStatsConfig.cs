using Gameplay;
using Gameplay.Stats;
using System;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "EntitiesStatsConfig", menuName = "Scriptable Objects/EntitiesStatsConfig")]
    public class EntitiesStatsConfig : ScriptableObject
    {
        public EntitityStatsConfig[] data => _data;
        [SerializeField] private EntitityStatsConfig[] _data;


        [Serializable]
        public struct EntitityStatsConfig
        {
            public EntityType type;
            public StatsConfig[] stats;
        }

        [Serializable]
        public struct StatsConfig
        {
            public StatType type;
            public float baseValue;
        }
    }
}