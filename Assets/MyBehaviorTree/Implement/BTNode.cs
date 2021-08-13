
namespace MyBehaviorTree
{
    public class BTNode : IBTNode
    {
        protected IBTNode _parent;
        protected BTStatus _status;
        protected string _name;

        public virtual IBTNode Parent { get => _parent; set => _parent = value; }
        public virtual BTStatus Status { get => _status; set => _status = value; }
        public virtual string Name { get => _name; set => _name = value; }

        public BTNode() 
        {
            _name = GetType().Name;
        }

        public virtual IBTNode Clone()
        {
            var clone = new BTNode();
            clone.Parent = Parent;
            clone.Status = Status;
            clone._name = _name;
            return clone;
        }

        public virtual void OnInitialize()
        {

        }

        public virtual void OnTerminate()
        {

        }

        public virtual void Tick()
        {

        }
    }
}