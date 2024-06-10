using System.Collections.Generic;

namespace Ecs
{
    /// <summary>
    /// 世界，管理实体、组件和系统
    /// </summary>
    public class World
    {
        public List<IEntity> Entities { get; set; } = new List<IEntity>();

        public ComponentPool[] ComponentPools { get; set; }
        
        public EntityPool[] EntityPools { get; set; }

        public List<ISystem> Systems { get; set; } = new List<ISystem>();

        public void Init()
        {
            //
        }

        public void Release()
        {
            //
        }

        public void Tick(float delta)
        {
            //
        }

        public IEntity newEntity()
        {
            return new Entity(1);
        }

        public IEntity GetEntity(int entityId)
        {
            return Entities[entityId];
        }

        public void RemoveEntity(int entityId)
        {
            //
        }
    }
}