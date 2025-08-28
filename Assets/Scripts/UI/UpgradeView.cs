using Data;
using Gameplay.Systems;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class UpgradeView : MonoBehaviour
    {
        public event Action<Upgrade> onBuy;

        [SerializeField] private Button _buyButton;
        [SerializeField] private TextMeshProUGUI _textMesh;
        private Upgrade _upgrade;
        private CurrencySystem _currencySystem;

        [Inject]
        private void Construct(CurrencySystem currencySystem)
        {
            _currencySystem = currencySystem;
        }

        public void Init(Upgrade upgrade)
        {
            _upgrade = upgrade;
            _textMesh.text = $"type:{upgrade.type} value:{upgrade.value} cost:{upgrade.cost}";
        }

        private void OnEnable()
        {
            _buyButton.onClick.AddListener(Buy);
        }

        private void OnDisable()
        {
            _buyButton.onClick.RemoveListener(Buy);
        }

        private void Buy()
        {
            if (_currencySystem.currency < _upgrade.cost)
            {
                Debug.Log("Not enough currency!");
                return;
            }
            onBuy?.Invoke(_upgrade);
        }
    }
}