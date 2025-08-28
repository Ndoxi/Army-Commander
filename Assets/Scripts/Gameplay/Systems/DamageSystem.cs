namespace Gameplay.Systems
{
    public class DamageSystem
    {
        private readonly LootDropSystem _lootDropSystem;

        public DamageSystem(LootDropSystem lootDropSystem)
        {
            _lootDropSystem = lootDropSystem;
        }

        public void ApplyDamage(IEntity target, float value)
        {
            target.ApplyDamage(value);
        }

        public void Register(IEntity entity)
        {
            entity.onDeath += HandleDeath;
        }

        public void Unregister(IEntity entity) 
        {
            entity.onDeath -= HandleDeath;
        }

        private void HandleDeath(IEntity entity)
        {
            _lootDropSystem.DropLoot(entity);
        }
    }
}