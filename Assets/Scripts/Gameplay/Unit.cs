using UnityEngine;

namespace Gameplay
{
    public class Unit : MonoBehaviour, IEntity
    {
        public Faction faction { get => _faction; set => _faction = value; }
        public Vector3 position => transform.position;

        private Faction _faction;
    }
}