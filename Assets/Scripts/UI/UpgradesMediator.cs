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
        private Action _callback;

        public UpgradesMediator(UpgradeSystem upgradeSystem, UpgradesView view)
        {
            _upgradeSystem = upgradeSystem;
            _view = view;
        }

        public void Init()
        {
            _view.onClose += CloseView;
            _view.onBuy += ApplyUpgrade;
        }

        public void Dispose()
        {
            _view.onClose -= CloseView;
            _view.onBuy -= ApplyUpgrade;
        }

        public void BeginUpgradeFlow(IUpgradable target, Action onComplete)
        {
            _target = target;
            _callback = onComplete;
            _view.Show(_upgradeSystem.GetUpgrades(target));
        }

        private void CloseView()
        {
            _target = null;
            _callback?.Invoke();
            _callback = null;

            _view.Hide();
        }

        private void ApplyUpgrade(Upgrade upgrade)
        {
            var success = _upgradeSystem.AddUpgrade(_target, upgrade.id);
            if (success)
                _view.Remove(upgrade.id);
        }
    }
}