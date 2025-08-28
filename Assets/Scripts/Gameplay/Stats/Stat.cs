using System;
using System.Collections.Generic;
using System.Linq;

namespace Gameplay.Stats
{
    public class Stat
    {
        public event Action<float> onValueUpdated;
        public float baseValue { get; private set; }
        public float value 
        { 
            get { return _value; } 
            set 
            {
                _value = value; 
                onValueUpdated?.Invoke(_value); 
            } 
        }
        private float _value;

        public Stat(float baseValue) 
        {
            this.baseValue = baseValue;
            _value = baseValue;
        }
    }
}