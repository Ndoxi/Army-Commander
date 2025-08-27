using Gameplay.Stats;
using Zenject;

namespace Core.Infrastracture
{
    public class StatFactory
    {
        private IInstantiator _instantiator;

        public StatFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public Stat Create(float baseValue)
        {
            return _instantiator.Instantiate<Stat>(new object[] { baseValue });
        }
    }
}