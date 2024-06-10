using System;

namespace Event 
{
    /// <summary>
    /// 事件管理器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class EventMgr<T> where T : EventArgs
    {
        public delegate void EventDelegate(T e);
        private static event EventDelegate Event;

        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="handler">委托</param>
        public static void Register(EventDelegate handler)
        {
            Event += handler;
        }

        /// <summary>
        /// 取消注册事件
        /// </summary>
        /// <param name="handler">委托</param>
        public static void Unregister(EventDelegate handler)
        {
            Event -= handler;
        }

        /// <summary>
        /// 触发事件
        /// </summary>
        /// <param name="e">事件</param>
        public static void Trigger(T e)
        {
            Event?.Invoke(e); // 调用所有注册的委托
        }
    }
}