using Gameplay;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "UnitFactoryData", menuName = "Scriptable Objects/UnitFactoryData")]
    public class UnitFactoryData : ScriptableObject
    {
        public Unit playerPrefab => _playerPrefab;
        public Unit unitPrefab => _unitPrefab;

        [SerializeField] private Unit _playerPrefab;
        [SerializeField] private Unit _unitPrefab;
    }       
}