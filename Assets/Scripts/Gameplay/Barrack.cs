using Core.Infrastracture;
using Data;
using Gameplay.Stats;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Barrack : Entity, IUpgradable, IInteractable
    {
        [SerializeField] private EntityType _spawnableEntityType;
        [SerializeField] private Vector3 _spawnOffset;
        private EntityFactory _factory;
        private UpgradesMediator _upgradesMediator;
        private Coroutine _spawnRoutine;
        private Stat _spawnRateStat;
        private readonly List<string> _upgradeIds = new List<string>();
        private readonly List<AllyBuffData> _allyBuffs = new List<AllyBuffData>();

        [Inject]
        private void Construct(EntityFactory factory, UpgradesMediator upgradesMediator)
        {
            _factory = factory;
            _upgradesMediator = upgradesMediator;
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

        public void Interact()
        {
            _upgradesMediator.SetTarget(this);
        }

        public void CompleteInteraction()
        {
            _upgradesMediator.SetTarget(null);
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
                Vector3 spawnPosition = transform.position 
                                        + transform.forward * _spawnOffset.z 
                                        + transform.right * _spawnOffset.x 
                                        + transform.up * _spawnOffset.y;

                var entity = _factory.Create(_spawnableEntityType, _faction, spawnPosition, transform.rotation);
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