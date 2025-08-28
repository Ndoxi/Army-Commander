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

        [Inject]
        private void Construct(CurrencySystem currencySystem)
        {
            _currencySystem = currencySystem;
        }

        public void Init(int reward, EntityType allowedEntityType)
        {
            _reward = reward;
            _allowedEntityType = allowedEntityType;
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