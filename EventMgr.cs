using System;

namespace ecs
{
    public static class EventMgr<T> where T : EventArgs
    {
        public delegate void EventDelegate(T e);
        private static event EventDelegate Event;

        public static void Register(EventDelegate handler)
        {
            Event += handler;
        }

        public static void Unregister(EventDelegate handler)
        {
            Event -= handler;
        }

        public static void Trigger(T e)
        {
            Event?.Invoke(e); // 调用所有注册的委托
        }
    }
}