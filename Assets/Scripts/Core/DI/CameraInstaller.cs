using Gameplay;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Core.DI
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private CinemachineCamera _camera;

        public override void InstallBindings()
        {
            Container.Bind<CameraFollowPlayer>()
                     .To<CameraFollowPlayer>()
                     .AsSingle()
                     .WithArguments(_camera);
        }
    }
}