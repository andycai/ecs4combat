using ecs.Enum;

namespace ecs
{
    public interface IComponent
    {
        int UUID { get; set; }
        Entity Entity { get; set; }
        ComponentType Type { get; set; }
        
        void Onload();
        void OnRecycle();
    }
}