using Data;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly Dictionary<string, UpgradeView> _views = new Dictionary<string, UpgradeView>();

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

                _views.Add(upgrade.id, view);
            }
        }

        public void Remove(string id)
        {
            if (!_views.TryGetValue(id, out UpgradeView view))
                return;

            Destroy(view.gameObject);
            _views.Remove(id);
        }

        public void Hide()
        {
            foreach (var view in _views)
            {
                view.Value.onBuy -= BuyUpgrade;
                Destroy(view.Value.gameObject);
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