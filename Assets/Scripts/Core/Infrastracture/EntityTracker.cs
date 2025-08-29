using Gameplay;
using System.Collections.Generic;

namespace Core.Infrastracture
{
    public class EntityTracker : Tracker<Entity>
    {
        public Entity FindPlayer()
        {
            return entities.Find(entity => entity.entityType == EntityType.Player);
        }

        public Entity FindHeadquarters()
        {
            return entities.Find(entity => entity.entityType == EntityType.Headquarters);
        }
    }
}