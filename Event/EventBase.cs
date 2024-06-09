using System;

namespace ecs.Event
{
    public abstract class EventBase : EventArgs
    {
        public string Name { get; }

        protected EventBase(string name)
        {
            Name = name;
        }
    }
}