using System;
using System.Collections.Generic;
using ecs.Enum;

namespace ecs
{
    /// <summary>
    /// 组件池
    /// </summary>
    public sealed class ComponentPool
    {
        /// <summary>
        /// 每个类型的组件池最多存放的组件数量
        /// </summary>
        private const int MaxComponent = 128;
        
        private readonly List<Component>[] _components;

        private readonly Func<Component> _create;

        private ComponentPool(Func<Component> create, int count)
        {
            _components = new List<Component>[count];
            _create = create;
        }

        public static ComponentPool Create(Func<Component> create, int count = 100)
        {
            return new ComponentPool(create, count);
        }

        /// <summary>
        /// 从池中获取组件
        /// </summary>
        /// <param name="type">组件类型</param>
        /// <returns>组件</returns>
        public Component Get(ComponentType type)
        {
            var index = (int)type;
            if (!IsValidIndex(index))
            {
                _components[index] = new List<Component>();
            }

            var list = _components[index];
            if (list.Count <= 0)
            {
                list.Add(_create.Invoke());
            }

            var component = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            component.Onload();
            
            return component;
        }

        /// <summary>
        /// 回收组件
        /// </summary>
        /// <param name="component">要回收的组件</param>
        public void Recycle(Component component)
        {
            var index = (int)component.Type;
            if (!IsValidIndex(index))
            {
                _components[index] = new List<Component>();
            }

            var list = _components[index];
            list.Add(component);
            
            component.OnRecycle();
            
            if (list.Count > MaxComponent)
            {
                list.RemoveRange(0, list.Count - MaxComponent);
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
            return index >= 0 && index < _components.Length;
        }
        
        #endregion
    }
}