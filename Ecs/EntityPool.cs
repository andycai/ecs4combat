using System;
using System.Collections.Generic;

namespace Ecs
{
    /// <summary>
    /// 实体池
    /// </summary>
    public sealed class EntityPool
    {
        /// <summary>
        /// 每个类型的实体池最多存放的数量
        /// </summary>
        private const int MaxEntity = 128;
        
        private readonly List<Entity>[] _entities;

        private readonly Func<Entity> _create;

        private EntityPool(Func<Entity> create, int count)
        {
            _entities = new List<Entity>[count];
            _create = create;
        }

        public static EntityPool Create(Func<Entity> create, int count = 100)
        {
            return new EntityPool(create, count);
        }

        /// <summary>
        /// 从池中获取实体
        /// </summary>
        /// <param name="type">实体类型</param>
        /// <returns>实体</returns>
        public Entity Get(int type)
        {
            var index = type;
            if (!IsValidIndex(index))
            {
                _entities[index] = new List<Entity>();
            }

            var list = _entities[index];
            if (list.Count <= 0)
            {
                list.Add(_create.Invoke());
            }

            var Entity = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            Entity.Onload();
            
            return Entity;
        }

        /// <summary>
        /// 回收实体
        /// </summary>
        /// <param name="entity">要回收的实体</param>
        public void Recycle(Entity entity)
        {
            var index = (int)entity.Type;
            if (!IsValidIndex(index))
            {
                _entities[index] = new List<Entity>();
            }

            var list = _entities[index];
            list.Add(entity);
            
            entity.OnRecycle();
            
            if (list.Count > MaxEntity)
            {
                list.RemoveRange(0, list.Count - MaxEntity);
            }
        }
        
        #region private methods

        /// <summary>
        /// 是否有效的索引
        /// </summary>
        /// <param name="index">索引值</param>
        /// <returns>是否有效</returns>
        private bool IsValidIndex(int index)
        {
            return index >= 0 && index < _entities.Length;
        }
        
        #endregion
    }
}