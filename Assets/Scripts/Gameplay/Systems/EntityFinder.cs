using UnityEngine;

namespace Gameplay.Systems
{
    public class EntityFinder
    {
        private readonly Collider[] _buffer;

        public EntityFinder()
        {
            _buffer = new Collider[50];
        }

        public IEntity Find(Vector3 center, Faction faction, float radius)
        {
            int hits = Physics.OverlapSphereNonAlloc(center, radius, _buffer);

            IEntity closest = null;
            float closestSqrDist = radius * radius;

            for (int i = 0; i < hits; i++)
            {
                if (_buffer[i].attachedRigidbody == null)
                    continue;

                var entity = _buffer[i].attachedRigidbody.GetComponent<IEntity>();
                if (entity == null || entity.faction != faction)
                    continue;

                float sqrDist = (entity.position - center).sqrMagnitude;
                if (sqrDist < closestSqrDist)
                {
                    closest = entity;
                    closestSqrDist = sqrDist;
                }
            }

            return closest;
        }
    }
}