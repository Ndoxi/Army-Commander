using Core.Input;
using System;
using UnityEngine;
using Zenject;

namespace Core.DI
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField] private JoystickInputReader _joystickInputReader;

        public override void InstallBindings()
        {
            Container.Bind(typeof(IInputReader), typeof(IDisposable))
                     .To<JoystickInputMediator>()
                     .AsSingle()
                     .WithArguments(_joystickInputReader)
                     .OnInstantiated<JoystickInputMediator>((context, mediator) => mediator.Init());
        }
    }
}