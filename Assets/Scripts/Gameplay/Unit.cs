using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Unit : Entity
    {
        protected override void OnDeath()
        {
            if (this == null)
                return;

            var colliders = GetComponentsInChildren<Collider>();
            foreach (var collider in colliders)
                collider.enabled = false;

            base.OnDeath();
        }
    }
}