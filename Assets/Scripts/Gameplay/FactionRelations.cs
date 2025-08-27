using Data;
using System.Collections.Generic;

namespace Gameplay
{
    public class FactionRelations
    {
        private readonly Dictionary<Faction, Faction> _enemies;

        public FactionRelations(FactionRelationsData data)
        {
            _enemies = new Dictionary<Faction, Faction>();

            foreach (var relation in data.relationDatas)
                _enemies.Add(relation.faction, relation.enemy);
        }

        public Faction GetEnemy(Faction faction)
        {
            return _enemies[faction];
        }
    }
}