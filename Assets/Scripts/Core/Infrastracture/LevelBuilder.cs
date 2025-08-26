using Data;

namespace Core.Infrastracture
{
    public class LevelBuilder
    {
        private readonly LevelBuilderData _data;
        private readonly UnitFactory _unitFactory;
        private readonly BuildingFactory _buildingFactory;

        public LevelBuilder(LevelBuilderData data, UnitFactory unitFactory, BuildingFactory buildingFactory)
        {
            _data = data;
            _unitFactory = unitFactory;
            _buildingFactory = buildingFactory;
        }

        public void CreateLevel()
        {
            _unitFactory.CreatePlayer(Gameplay.Faction.Player, _data.playerSpawnPosition);

            foreach (var data in _data.barrackDatas)
                _buildingFactory.CreateBarrack(data.faction, data.position);
        }

        public void DestroyLevel()
        {

        }
    }
}