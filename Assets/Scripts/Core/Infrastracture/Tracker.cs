using System.Collections.Generic;

namespace Core.Infrastracture
{
    public class Tracker<T>
    {
        public List<T> entities => _entities;
        private readonly List<T> _entities = new List<T>(20);

        public void Register(T entity)
        {
            if (!_entities.Contains(entity))
                _entities.Add(entity);
        }

        public void Unregister(T entity)
        {
            _entities.Remove(entity);
        }

        public void UnregisterAll()
        {
            _entities.Clear();
        }
    }
}