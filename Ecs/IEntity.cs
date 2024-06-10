namespace Ecs
{
    public interface IEntity
    {
        int UUID { get; set; }
        int Type { get; set; }
        IComponent[] Components { get; set; }
        
        IComponent GetComponent(int type);
        IComponent AddComponent(int type);
        bool RemoveComponent(int type);

        void Onload();
        void OnRecycle();
    }
}