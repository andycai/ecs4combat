namespace Ecs
{
    public interface ISystem
    {
        void Initialize();
        void Execute();
        void Tick(double delta);
    }
}