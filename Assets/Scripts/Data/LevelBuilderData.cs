using Gameplay;
using System;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "LevelBuilderData", menuName = "Scriptable Objects/LevelBuilderData")]
    public class LevelBuilderData : ScriptableObject
    {
        public SpawnPointData[] spawnPointDatas => _spawnPointDatas;
        [SerializeField] private SpawnPointData[] _spawnPointDatas;


        [Serializable]
        public struct SpawnPointData
        {
            public Vector3 position;
            public Quaternion rotation;
            public EntityType entityType;
            public Faction faction;
        }
    }
}