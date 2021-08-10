
namespace BehaviorTree
{
    public class BTNode : IBTNode
    {
        protected IBTNode _parent;
        protected BTStatus _status;
        protected string _name;

        public IBTNode Parent { get => _parent; set => _parent = value; }
        public BTStatus Status { get => _status; set => _status = value; }

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

        public bool OnInitialize()
        {
            throw new System.NotImplementedException();
        }

        public bool OnTerminate()
        {
            throw new System.NotImplementedException();
        }

        public void Tick()
        {
            throw new System.NotImplementedException();
        }
    }
}