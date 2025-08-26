using Core.Infrastracture;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Barrack : MonoBehaviour, IEntity
    {
        public Faction faction { get => _faction; set => _faction = value; }

        [SerializeField] private Vector3 _spawnOffset;
        [SerializeField] private float _baseSpawnInterval = 1.5f;
        private UnitFactory _factory;
        private Faction _faction;
        private Coroutine _spawnRoutine;

        [Inject]
        private void Construct(UnitFactory factory)
        {
            _factory = factory;
        }

        private void OnEnable()
        {
            _spawnRoutine = StartCoroutine(SpawnLoopCo());
        }

        private void OnDisable()
        {
            if (_spawnRoutine != null)
            {
                StopCoroutine(_spawnRoutine);
                _spawnRoutine = null;
            }
        }

        private IEnumerator SpawnLoopCo()
        {
            while (true)
            {
                _factory.CreateUnit(_faction, transform.position + _spawnOffset);
                yield return new WaitForSeconds(_baseSpawnInterval);
            }
        }
    }
}