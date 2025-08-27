using Core.Infrastracture;
using Gameplay.Stats;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Barrack : Entity
    {
        [SerializeField] private EntityType _spawnableEntityType;
        [SerializeField] private Vector3 _spawnOffset;
        private EntityFactory _factory;
        private Coroutine _spawnRoutine;
        private Stat _spawnRate;
            
        [Inject]
        private void Construct(EntityFactory factory)
        {
            _factory = factory;
        }

        private void Start()
        {
            _spawnRate = GetStat(StatType.SpawnRate);
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
                Vector3 spawnPosition = transform.position 
                                        + transform.forward * _spawnOffset.z 
                                        + transform.right * _spawnOffset.x 
                                        + transform.up * _spawnOffset.y;

                _factory.Create(_spawnableEntityType, _faction, spawnPosition, transform.rotation);
                yield return new WaitForSeconds(_spawnRate.value);
            }
        }
    }
}