using Data;

namespace Core.Infrastracture
{
    public class LevelBuilder
    {
        private readonly LevelBuilderData _data;
        private readonly EntityFactory _entityFactory;

        public LevelBuilder(LevelBuilderData data, EntityFactory entityFactory)
        {
            _data = data;
            _entityFactory = entityFactory;
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

        }
    }
}