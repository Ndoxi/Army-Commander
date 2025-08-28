using Data;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class UpgradesView : MonoBehaviour
    {
        public event Action onClose;
        public event Action<Upgrade> onBuy;

        [SerializeField] private RectTransform _root;
        [SerializeField] private Button _closeButton;
        [SerializeField] private RectTransform _content;
        [SerializeField] private UpgradeView _upgradeViewPrefab;
        private IInstantiator _instantiator;
        private readonly List<UpgradeView> _views = new List<UpgradeView>();

        [Inject]
        private void Construct(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        private void Awake()
        {
            Hide();
        }

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(Close);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(Close);
        }

        public void Show(Upgrade[] upgrades)
        {
            _root.gameObject.SetActive(true);

            foreach (var upgrade in upgrades)
            {
                var view = _instantiator.InstantiatePrefabForComponent<UpgradeView>(_upgradeViewPrefab, _content);
                view.Init(upgrade);
                view.onBuy += BuyUpgrade;

                _views.Add(view);
            }
        }

        public void Hide()
        {
            foreach (var view in _views)
            {
                view.onBuy -= BuyUpgrade;
                Destroy(view.gameObject);
            }
            _views.Clear();

            _root.gameObject.SetActive(false);
        }

        private void Close()
        {
            onClose?.Invoke();
        }

        private void BuyUpgrade(Upgrade upgrade)
        {
            onBuy?.Invoke(upgrade);
        }
    }
}