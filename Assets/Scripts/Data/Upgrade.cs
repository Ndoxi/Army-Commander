using Gameplay;
using Gameplay.Stats;
using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class Upgrade
    {
        public string id;
        public UpgradeType type;
        public EntityType targetEntityType;
        public StatType statType;
        public float value;
        public int cost;
        public string description;
    }
}