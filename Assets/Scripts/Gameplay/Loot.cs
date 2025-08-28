using Core.Infrastracture;
using Gameplay.Systems;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Loot : MonoBehaviour
    {
        private int _reward;
        private EntityType _allowedEntityType;
        private CurrencySystem _currencySystem;
        private LootTracker _lootTracker;

        [Inject]
        private void Construct(CurrencySystem currencySystem, LootTracker lootTracker)
        {
            _currencySystem = currencySystem;
            _lootTracker = lootTracker;
        }

        public void Init(int reward, EntityType allowedEntityType)
        {
            _reward = reward;
            _allowedEntityType = allowedEntityType;
        }

        private void OnEnable()
        {
            _lootTracker.Register(this);
        }

        private void OnDisable()
        {
            _lootTracker.Unregister(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            var entity = GetEntity(other);
            if (entity == null || entity.entityType != _allowedEntityType)
                return;

            _currencySystem.currency += _reward;
            Destroy(gameObject);
        }

        private IEntity GetEntity(Collider collider)
        {
            if (collider.attachedRigidbody == null 
                || !collider.attachedRigidbody.TryGetComponent(out IEntity entity))
            {
                return null;
            }

            return entity;
        }
    }
}