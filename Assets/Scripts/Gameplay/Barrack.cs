using Core.Infrastracture;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Barrack : MonoBehaviour, IEntity
    {
        public Faction faction { get => _faction; set => _faction = value; }
        public Vector3 position => transform.position;

        [SerializeField] private Vector3 _spawnOffset;
        [SerializeField] private float _baseSpawnInterval = 1.5f;
        private UnitFactory _factory;
        private Faction _faction;
        private Coroutine _spawnRoutine;
        private bool _initialized = false;

        [Inject]
        private void Construct(UnitFactory factory)
        {
            _factory = factory;
        }

        public void Init(Faction faction)
        {
            _faction = faction;
            _initialized = true;
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
            yield return new WaitUntil(() => _initialized);

            while (true)
            {
                _factory.CreateUnit(_faction, transform.position + _spawnOffset, transform.rotation);
                yield return new WaitForSeconds(_baseSpawnInterval);
            }
        }
    }
}