namespace Ecs
{
    public interface IComponent
    {
        int UUID { get; set; }
        Entity Entity { get; set; }
        int Type { get; set; }

        void Onload();
        void OnRecycle();
    }
}