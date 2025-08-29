using Gameplay.Stats;
using Gameplay.Systems;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    [RequireComponent(typeof(IEntity))]
    public class HpStatProvider : MonoBehaviour, IStatHudProvider
    {
        public Stat stat => _stat; 
        public StatType statType => StatType.Health;
        public Faction faction => _entity.faction;
        public EntityType entityType => _entity.entityType;
        public Vector3 position => _entity.position;

        private IEntity _entity;
        private Stat _stat;
        private UnitHudTracker _hudTracker;

        [Inject]
        private void Construct(UnitHudTracker hudTracker)
        {
            _hudTracker = hudTracker;
        }

        private void Awake()
        {
            _entity = GetComponent<IEntity>();
        }

        private void Start()
        {
            _stat = _entity.GetStat(StatType.Health);
        }

        private void OnEnable()
        {
            _hudTracker.Register(this);
        }

        private void OnDisable()
        {
            _hudTracker.Unregister(this);
        }
    }
}