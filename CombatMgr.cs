using System.Collections.Generic;

namespace ecs
{
    public class CombatMgr
    {
        public List<IEntity> Entities { get; set; }
        public List<IComponent> Components { get; set; }
        public List<ISystem> Systems { get; set; }

        public CombatMgr()
        {
            Entities = new List<IEntity>();
            Components = new List<IComponent>();
            Systems = new List<ISystem>();
        }

        public void AddEntity(int id)
        {
            Entities.Add(new Entity(id));
        }

        public void AddComponent<T>(int entityId) where T : Component, new()
        {
            var component = new T();
            // component.EntityId = entityId;
            Components.Add(component);

            var entity = Entities.Find(e => e.UUID == entityId);
            if (entity != null)
            {
                entity.Components[0] = component;
            }
        }

        public void AddSystem<T>(List<IEntity> entities) where T : ISystem, new()
        {
            var system = new T();
            Systems.Add(system);
        }
    }
}