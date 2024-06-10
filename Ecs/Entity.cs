namespace Ecs
{
    /// <summary>
    /// The Entity Component System (ECS) is a design pattern that separates an object's data (components) from its behavior (systems).
    /// Entity 可以是英雄、技能、Buff、子物体（如弹道）、召唤物等
    /// </summary>
    public class Entity : IEntity

    {
        public int UUID { get; set; }

        public int Type { get; set; }
        
        // public Archetype archetype;
        public IComponent[] Components { get; set; }

        public Entity()
        {
            
        }

        public Entity(int id)
        {
            UUID = id;
        }

        public IComponent GetComponent(int type)
        {
            return Components[type];
        }

        public IComponent AddComponent(int type)
        {
            return new Component(1, type, this);
        }

        public bool RemoveComponent(int type)
        {
            if (Components[type] == null) return false;

            Components[type] = null;
            return true;
        }
        
        /// <summary>
        /// 实体生成时调用
        /// </summary>
        public void Onload()
        {
            //
        }

        /// <summary>
        /// 实体回收时调用
        /// </summary>
        public void OnRecycle()
        {
            //
        }
    }
}