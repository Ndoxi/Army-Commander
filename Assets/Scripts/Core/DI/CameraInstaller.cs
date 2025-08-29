using Gameplay;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Core.DI
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private CinemachineCamera _cinemachineCamera;

        public override void InstallBindings()
        {
            Container.Bind<Camera>().FromInstance(_camera);

            Container.Bind<CameraFollowPlayer>()
                     .To<CameraFollowPlayer>()
                     .AsSingle()
                     .WithArguments(_cinemachineCamera);
        }
    }
}