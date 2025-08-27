using Gameplay;
using System;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "LevelBuilderData", menuName = "Scriptable Objects/LevelBuilderData")]
    public class LevelBuilderData : ScriptableObject
    {
        public Vector3 playerSpawnPosition => _playerSpawnPosition;
        public BarrackSpawnPointData[] barrackDatas => _barrackDatas;

        [SerializeField] private Vector3 _playerSpawnPosition;
        [SerializeField] private BarrackSpawnPointData[] _barrackDatas;

        [Serializable]
        public struct BarrackSpawnPointData
        {
            public Vector3 position;
            public Quaternion rotation;
            public Faction faction;
        }
    }
}