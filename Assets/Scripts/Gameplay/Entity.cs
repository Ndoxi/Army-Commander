using Gameplay.Stats;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Entity : MonoBehaviour, IEntity
    {
        public Faction faction => _faction;
        public Vector3 position => transform.position;

        protected Faction _faction;
        protected Dictionary<StatType, Stat> _stats;

        public void Init(Faction faction, Dictionary<StatType, Stat> stats)
        {
            _faction = faction;
            _stats = stats;
        }

        public Stat GetStat(StatType statType)
        {
            return _stats[statType];
        }
    }
}