
namespace MyBehaviorTree
{
    public class BTActionNode : IBTActionNode
    {
        protected IBTNode _parent;
        protected BTStatus _status;
        protected string _name;

        public virtual IBTNode Parent { get => _parent; set => _parent = value; }
        public virtual BTStatus Status { get => _status; set => _status = value; }
        public virtual string Name { get => _name; set => _name = value; }

        public BTActionNode()
        {
            _name = GetType().Name;
        }

        public IBTNode Clone()
        {
            var clone = new BTActionNode();
            clone.Parent = Parent;
            clone.Status = Status;
            clone._name = _name;
            return clone;
        }

        public virtual void OnInitialize()
        {
            Status = BTStatus.Running;
        }

        public virtual void OnTerminate()
        {
            Status = BTStatus.Success;
        }

        public virtual void Tick()
        {

        }
    }
}