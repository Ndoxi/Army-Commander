using Core.Infrastracture;
using Unity.Cinemachine;

namespace Gameplay
{
    public class CameraFollowPlayer
    {
        private readonly CinemachineCamera _camera;
        private readonly EntityTracker _entityTracker;

        public CameraFollowPlayer(CinemachineCamera camera, EntityTracker entityTracker)
        {
            _camera = camera;
            _entityTracker = entityTracker;
        }

        public void Init()
        {
            _camera.Follow = _entityTracker.FindPlayer().transform;
        }
    }
}