using Core.Infrastracture;
using Cysharp.Threading.Tasks;
using Data;
using System;
using System.Linq;
using System.Threading;
using Utils;

namespace Gameplay.Systems
{
    public class LootDropSystem : IDisposable
    {
        private const float DropDelay = 1.5f;

        private readonly LootTable _lootTable;
        private readonly LootFactory _lootFactory;
        private readonly CancellationTokenSource _cts;

        public LootDropSystem(LootTable lootTable, LootFactory lootFactory)
        {
            _lootTable = lootTable;
            _lootFactory = lootFactory;
            _cts = new CancellationTokenSource();
        }

        public void Dispose()
        {
            _cts.Cancel();
            _cts.Dispose();
        }

        public void DropLoot(IEntity entity)
        {
            DropLootDelayed(entity, _cts.Token).Forget();
        }

        private LootTable.LootData GetDrop(EntityType entityType, Faction faction)
        {
            return _lootTable.loot.FirstOrDefault(loot => loot.dropedBy == entityType && loot.faction == faction);
        }

        private async UniTaskVoid DropLootDelayed(IEntity entity, CancellationToken cancellationToken)
        {
            var lootData = GetDrop(entity.entityType, entity.faction);
            if (lootData.reward <= 0)
                return;

            var position = entity.position;
            var calceled = await UniTask.Delay(TimeUtils.ToMilliseconds(DropDelay), cancellationToken: cancellationToken)
                                        .SuppressCancellationThrow();
            if (calceled)
                return;

            _lootFactory.Create(lootData.reward, lootData.allowedEntityType, position);
        }
    }
}