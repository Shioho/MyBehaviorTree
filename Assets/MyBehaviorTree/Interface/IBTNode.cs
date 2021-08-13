
namespace MyBehaviorTree
{
    public interface IBTNode
    {
        IBTNode Parent { get; set; }
        BTStatus Status { get; set; }
        string Name { get; set; }
        void OnInitialize();
        void OnTerminate();
        void Tick();
        IBTNode Clone();
    }
}