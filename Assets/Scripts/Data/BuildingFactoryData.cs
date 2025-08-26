using Gameplay;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "BuildingFactoryData", menuName = "Scriptable Objects/BuildingFactoryData")]
    public class BuildingFactoryData : ScriptableObject
    {
        public Barrack barrackPrefab => _barrackPrefab;
        [SerializeField] private Barrack _barrackPrefab;
    }
}