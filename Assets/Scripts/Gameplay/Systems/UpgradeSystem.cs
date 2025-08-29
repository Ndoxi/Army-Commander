using Data;
using System.Linq;

namespace Gameplay.Systems
{
    public class UpgradeSystem
    {
        private readonly CurrencySystem _currencySystem;
        private readonly UpgradeConfig _upgradeConfig;

        public UpgradeSystem(CurrencySystem currencySystem, UpgradeConfig upgradeConfig)
        {
            _currencySystem = currencySystem;
            _upgradeConfig = upgradeConfig;
        }

        public bool AddUpgrade(IUpgradable entity, string id)
        {
            var upgrades = GetUpgrades(entity);
            var upgrade = upgrades.First(u => u.id == id);

            if (_currencySystem.currency < upgrade.cost)
                return false;

            _currencySystem.currency -= upgrade.cost;
            entity.AddUpgrade(upgrade.id, upgrade.type, upgrade.statType, upgrade.value);
            return true;
        }

        public Upgrade[] GetUpgrades(IUpgradable entity)
        {
            var appliedIds = entity.GetUpgrades();
            return _upgradeConfig.upgrades.Where(upgrade => upgrade.targetEntityType == entity.entityType 
                                                                    && !appliedIds.Contains(upgrade.id))
                                          .ToArray();
        }
    }
}