using UnityEngine;

namespace Gameplay
{
    public class Unit : MonoBehaviour, IEntity
    {
        public Faction faction { get => _faction; set => _faction = value; }
        private Faction _faction;
    }
}