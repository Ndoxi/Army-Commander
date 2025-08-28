using Core.Infrastracture;
using Gameplay.Stats;
using Gameplay.Systems;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Entity : MonoBehaviour, IEntity
    {
        public event Action<IEntity> onDeath;
        public Faction faction => _faction;
        public EntityType entityType => _entityType;
        public Vector3 position => transform.position;

        protected Faction _faction;
        protected EntityType _entityType;
        protected Dictionary<StatType, Stat> _stats;
        private DamageSystem _damageSystem;
        private EntityTracker _entityTracker;

        [Inject]
        private void Construct(DamageSystem damageSystem, EntityTracker entityTracker)
        {
            _damageSystem = damageSystem;
            _entityTracker = entityTracker;
        }

        public void Init(EntityType entityType, Faction faction, Dictionary<StatType, Stat> stats)
        {
            _entityType = entityType;
            _faction = faction;
            _stats = stats;
        }

        private void OnEnable()
        {
            _damageSystem.Register(this);
            _entityTracker.Register(this);
        }

        private void OnDisable()
        {
            _damageSystem.Unregister(this);
            _entityTracker.Unregister(this);
        }

        public Stat GetStat(StatType statType)
        {
            return _stats[statType];
        }

        public void ApplyDamage(float value)
        {
            var healthStat = GetStat(StatType.Health);
            if (healthStat.value <= 0)
                return;

            healthStat.value -= value;
            if (healthStat.value <= 0)
            {
                healthStat.value = 0;
                OnDeath();
            }
        }

        private void OnDeath()
        {
            onDeath?.Invoke(this);
            Destroy(gameObject);
        }
    }
}