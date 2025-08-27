using System.Collections.Generic;
using System.Linq;

namespace Gameplay.Stats
{
    public class Stat
    {
        public float baseValue { get; private set; }
        public float value { get; private set; }
        private readonly List<float> _modifiers;

        public Stat(float baseValue) 
        {
            _modifiers = new List<float>();
            this.baseValue = baseValue;
            value = baseValue;
        }

        public void AddModifier(float value) 
        {
            _modifiers.Add(value);
            RecalculateValue();
        }

        public void RemoveModifier(float value)
        {
            _modifiers.Remove(value);
            RecalculateValue();
        }

        private void RecalculateValue()
        {
            value = baseValue + _modifiers.Sum();
        }
    }
}