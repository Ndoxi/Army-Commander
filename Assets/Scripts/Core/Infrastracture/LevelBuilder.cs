using Data;

namespace Core.Infrastracture
{
    public class LevelBuilder
    {
        private readonly LevelBuilderData _data;
        private readonly UnitFactory _unitFactory;
        private readonly BuildingFactory _barrackFactory;

        public LevelBuilder(LevelBuilderData data, UnitFactory unitFactory, BuildingFactory barrackFactory)
        {
            _data = data;
            _unitFactory = unitFactory;
            _barrackFactory = barrackFactory;
        }

        public void CreateLevel()
        {
            _unitFactory.CreatePlayer(_data.playerSpawnPosition);
        }

        public void DestroyLevel()
        {

        }
    }
}