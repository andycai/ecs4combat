using ecs.Enum;

namespace ecs
{
    public class Component : IComponent
    {
        public int UUID { get; set; }
        public ComponentType Type { get; set; }
        public Entity Entity { get; set; }

        public Component(int id, ComponentType type, Entity entity)
        {
            UUID = id;
            Type = type;
            Entity = entity;
        }

        /// <summary>
        /// 组件生成时调用
        /// </summary>
        public void Onload()
        {
            //
        }

        /// <summary>
        /// 组件回收时调用
        /// </summary>
        public void OnRecycle()
        {
            //
        }
    }
}