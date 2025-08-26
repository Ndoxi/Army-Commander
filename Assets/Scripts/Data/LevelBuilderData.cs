using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "LevelBuilderData", menuName = "Scriptable Objects/LevelBuilderData")]
    public class LevelBuilderData : ScriptableObject
    {
        public Vector3 playerSpawnPosition => _playerSpawnPosition;
        [SerializeField] private Vector3 _playerSpawnPosition;
    }
}