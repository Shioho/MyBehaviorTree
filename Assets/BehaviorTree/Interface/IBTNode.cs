
namespace BehaviorTree
{
    public interface IBTNode
    {
        IBTNode Parent { get; set; }
        BTStatus Status { get; set; }
        bool OnInitialize();
        bool OnTerminate();
        void Tick();
        IBTNode Clone();
    }
}