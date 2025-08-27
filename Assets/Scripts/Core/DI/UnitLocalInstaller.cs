using Gameplay;
using UnityEngine;
using Zenject;

namespace Core.DI
{
    public class UnitLocalInstaller : MonoInstaller
    {
        [SerializeField] private Unit _unit;
        [SerializeField] private UnitMovement _unitMovement;

        public override void InstallBindings()
        {
            Container.Bind<IEntity>().FromInstance(_unit);
            Container.Bind<UnitMovement>().FromInstance(_unitMovement);
        }
    }
}