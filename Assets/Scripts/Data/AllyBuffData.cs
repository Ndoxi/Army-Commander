using Gameplay.Stats;

namespace Data
{
    public struct AllyBuffData
    {
        public StatType statType; 
        public float value;

        public AllyBuffData(StatType statType, float value)
        {
            this.statType = statType;
            this.value = value;
        }
    }
}