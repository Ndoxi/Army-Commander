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
        [SerializeField] private TextMeshProUGUI _priceTextMesh;
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
            _textMesh.text = upgrade.description;
            _priceTextMesh.text = upgrade.cost.ToString();
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
                return;

            onBuy?.Invoke(_upgrade);
        }
    }
}