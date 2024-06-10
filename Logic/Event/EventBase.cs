using System;

namespace Logic.Event
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