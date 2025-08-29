using Gameplay;
using UnityEngine;
using Zenject;

namespace Core.DI
{
    public class UnitLocalInstaller : MonoInstaller
    {
        [SerializeField] private Unit _unit;
        [SerializeField] private UnitMovement _unitMovement;
        [SerializeField] private UnitAnimator _unitAnimator;

        public override void InstallBindings()
        {
            Container.Bind(typeof(IEntity), typeof(Unit)).FromInstance(_unit);
            Container.Bind<UnitMovement>().FromInstance(_unitMovement);
            Container.Bind<UnitAnimator>().FromInstance(_unitAnimator);
        }
    }
}