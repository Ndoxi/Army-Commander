using Gameplay;
using System;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "FactionRelationsData", menuName = "Scriptable Objects/FactionRelationsData")]
    public class FactionRelationsData : ScriptableObject
    {
        public RelationData[] relationDatas => _relationDatas;
        [SerializeField] private RelationData[] _relationDatas;

        [Serializable]
        public struct RelationData
        {
            public Faction faction;
            public Faction enemy;
        }
    }    
}