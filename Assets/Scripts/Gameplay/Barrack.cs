using Core.Infrastracture;
using Data;
using Gameplay.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Barrack : Entity, IUpgradable
    {
        [SerializeField] private EntityType _spawnableEntityType;
        [SerializeField] private Vector3 _spawnOffset;
        [SerializeField] private float _spawnRadius = 1f;
        private EntityFactory _factory;
        private Coroutine _spawnRoutine;
        private Stat _spawnRateStat;
        private readonly List<string> _upgradeIds = new List<string>();
        private readonly List<AllyBuffData> _allyBuffs = new List<AllyBuffData>();

        [Inject]
        private void Construct(EntityFactory factory)
        {
            _factory = factory;
        }

        public void AddUpgrade(string id, UpgradeType type, StatType statType, float value)
        {
            _upgradeIds.Add(id);

            switch (type)
            {
                case UpgradeType.BuffStat:
                    var stat = GetStat(statType);
                    stat.value += value;
                    break;

                case UpgradeType.BuffAlly:
                    _allyBuffs.Add(new AllyBuffData(statType, value));
                    break;
            }
        }

        public string[] GetUpgrades()
        {
            return _upgradeIds.ToArray();
        }

        private void Start()
        {
            _spawnRateStat = GetStat(StatType.SpawnRate);
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
                Vector3 spawnCenter = transform.position 
                                      + transform.forward * _spawnOffset.z 
                                      + transform.right * _spawnOffset.x 
                                      + transform.up * _spawnOffset.y;

                Vector2 randomCircle = Random.insideUnitCircle * _spawnRadius;
                var randomOffset = new Vector3(randomCircle.x, 0, randomCircle.y);

                var entity = _factory.Create(_spawnableEntityType, _faction, spawnCenter + randomOffset, transform.rotation);
                foreach (var buff in _allyBuffs)
                {
                    var stat = entity.GetStat(buff.statType);
                    stat.value += buff.value;
                }

                yield return new WaitForSeconds(_spawnRateStat.value);
            }
        }
    }
}