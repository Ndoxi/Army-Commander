using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "UpgradeConfig ", menuName = "Scriptable Objects/UpgradeConfig ")]
    public class UpgradeConfig : ScriptableObject
    {
        public Upgrade[] upgrades => _upgrades;
        [SerializeField] private Upgrade[] _upgrades;
    }
}