using System;

namespace ecs.Event
{
    public class EventComponent : EventBase
    {
        public const string AddComponent = "AddComponent";
        public const string RemoveComponent = "RemoveComponent";
        
        public EventComponent(string name) : base(name)
        {
        }
    }
}