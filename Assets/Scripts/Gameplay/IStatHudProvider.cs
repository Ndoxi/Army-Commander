using Gameplay.Stats;
using UnityEngine;

namespace Gameplay
{
    public interface IStatHudProvider
    {
        Stat stat { get; }
        StatType statType { get; }
        Faction faction { get; }
        EntityType entityType { get; }
        Vector3 position { get; }
    }
}