using System.Collections.Generic;

namespace ecs
{
    public abstract class System
    {
        public List<Entity> Entities { get; set; }

        public System(List<Entity> entities)
        {
            Entities = entities;
        }

        public virtual void Update()
        {
            // Implement update logic here
        }
    }

    public abstract class Task
    {
        public System System { get; set; }

        public Task(System system)
        {
            System = system;
        }

        public virtual void Execute()
        {
            // Implement execute logic here
        }
    }

}