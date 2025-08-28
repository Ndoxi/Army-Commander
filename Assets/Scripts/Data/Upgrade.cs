using Gameplay;
using Gameplay.Stats;
using System;

namespace Data
{
    [Serializable]
    public class Upgrade
    {
        public string id => _id;
        public UpgradeType type;
        public EntityType targetEntityType;
        public StatType statType;
        public float value;
        public int cost;

        private string _id = Guid.NewGuid().ToString();
    }
}