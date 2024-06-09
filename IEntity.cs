using ecs.Enum;

namespace ecs
{
    public interface IEntity
    {
        int UUID { get; set; }
        EntityType Type { get; set; }
        IComponent[] Components { get; set; }
        
        IComponent GetComponent(ComponentType type);
        IComponent AddComponent(ComponentType type);
        bool RemoveComponent(ComponentType type);

        void Onload();
        void OnRecycle();
    }
}