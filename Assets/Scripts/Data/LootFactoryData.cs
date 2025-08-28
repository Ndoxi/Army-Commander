using Gameplay;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "LootFactoryData", menuName = "Scriptable Objects/LootFactoryData")]
    public class LootFactoryData : ScriptableObject
    {
        public Loot prefab => _prefab;
        [SerializeField] private Loot _prefab;
    }
}