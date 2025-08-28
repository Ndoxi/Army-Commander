using System;

namespace Gameplay.Systems
{
    public class CurrencySystem
    {
        public event Action<int> onUpdate;
        public int currency 
        { 
            get { return _currency; } 
            set 
            { 
                _currency = value; 
                onUpdate?.Invoke(_currency); 
            }
        }

        private int _currency;
    }
}