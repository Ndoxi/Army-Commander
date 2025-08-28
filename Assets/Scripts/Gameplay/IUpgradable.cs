using Gameplay.Stats;

namespace Gameplay
{
    public interface IUpgradable
    {
        EntityType entityType { get; }
        void AddUpgrade(string id, UpgradeType type, StatType statType, float value);
        string[] GetUpgrades();
    }
}