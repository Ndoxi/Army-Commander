using Core.Infrastracture;
using Data;
using System.Linq;

namespace Gameplay.Systems
{
    public class LootDropSystem
    {
        private readonly LootTable _lootTable;
        private readonly LootFactory _lootFactory;

        public LootDropSystem(LootTable lootTable, LootFactory lootFactory)
        {
            _lootTable = lootTable;
            _lootFactory = lootFactory;
        }

        public void DropLoot(IEntity entity)
        {
            var lootData = GetDrop(entity.entityType, entity.faction);
            if (lootData.reward <= 0)
                return;

            _lootFactory.Create(lootData.reward, lootData.allowedEntityType, entity.position);
        }

        private LootTable.LootData GetDrop(EntityType entityType, Faction faction)
        {
            return _lootTable.loot.FirstOrDefault(loot => loot.dropedBy == entityType && loot.faction == faction);
        }
    }
}