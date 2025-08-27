using Gameplay.Stats;
using UnityEngine;

namespace Gameplay
{
    public interface IEntity
    {
        Faction faction { get; }
        Vector3 position { get; }
        Stat GetStat(StatType statType); 
    }
}