using UnityEngine;

namespace Gameplay
{
    public interface IEntity
    {
        Faction faction { get; set; }
        Vector3 position { get; }
    }
}