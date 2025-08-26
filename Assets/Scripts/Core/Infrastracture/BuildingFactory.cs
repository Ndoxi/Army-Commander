using UnityEngine;
using Zenject;

namespace Core.Infrastracture
{
    public class BuildingFactory
    {
        private readonly IInstantiator _instantiator;

        public BuildingFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }
    }
}