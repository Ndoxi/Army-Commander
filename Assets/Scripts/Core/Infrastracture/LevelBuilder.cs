using Data;
using UnityEngine;

namespace Core.Infrastracture
{
    public class LevelBuilder
    {
        private readonly LevelBuilderData _data;
        private readonly EntityFactory _entityFactory;
        private readonly EntityTracker _entityTracker;
        private readonly LootTracker _lootTracker;

        public LevelBuilder(LevelBuilderData data,
                            EntityFactory entityFactory,
                            EntityTracker entityTracker, 
                            LootTracker lootTracker)
        {
            _data = data;
            _entityFactory = entityFactory;
            _entityTracker = entityTracker;
            _lootTracker = lootTracker;
        }

        public void CreateLevel()
        {
            foreach (var spawnPoint in _data.spawnPointDatas)
            {
                _entityFactory.Create(spawnPoint.entityType,
                                      spawnPoint.faction,
                                      spawnPoint.position,
                                      spawnPoint.rotation);
            }
        }

        public void DestroyLevel()
        {
            foreach (var entity in _entityTracker.entities.ToArray())
            {
                if (entity != null)
                    Object.Destroy(entity.gameObject);
            }
            _entityTracker.UnregisterAll();

            foreach (var loot in _lootTracker.entities.ToArray())
            {
                if (loot != null)
                    Object.Destroy(loot.gameObject);
            }
            _lootTracker.UnregisterAll();
        }
    }
}