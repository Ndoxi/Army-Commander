using Data;
using Gameplay;
using Gameplay.Systems;
using System;

namespace UI
{
    public class UpgradesMediator : IDisposable
    {
        private readonly UpgradeSystem _upgradeSystem;
        private readonly UpgradesView _view;
        private IUpgradable _target;

        public UpgradesMediator(UpgradeSystem upgradeSystem, UpgradesView view)
        {
            _upgradeSystem = upgradeSystem;
            _view = view;
        }

        public void Init()
        {
            _view.onClose += CloseView;
            _view.onBuy += BuyUpgrade;
        }

        public void Dispose()
        {
            _view.onClose -= CloseView;
            _view.onBuy -= BuyUpgrade;
        }

        public void SetTarget(IUpgradable upgradable)
        {
            _target = upgradable;

            if (upgradable != null)
                _view.Show(_upgradeSystem.GetUpgrades(upgradable));
            else
                _view.Hide();
        }

        private void CloseView()
        {
            _view.Hide();
        }

        private void BuyUpgrade(Upgrade upgrade)
        {
            _upgradeSystem.AddUpgrade(_target, upgrade.id);
        }
    }
}