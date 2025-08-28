using Data;
using Gameplay.Stats;
using System;
using UnityEngine;

namespace Gameplay
{
    public interface IEntity
    {
        event Action<IEntity> onDeath;
        Faction faction { get; }
        EntityType entityType { get; }
        Vector3 position { get; }
        Stat GetStat(StatType statType);
        void ApplyDamage(float value);
    }
}