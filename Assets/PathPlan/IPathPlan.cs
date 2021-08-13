
using System.Collections.Generic;
using UnityEngine;

namespace Shioho
{
    public interface IPathPlan
    {
        List<Vector3> CalculatePath(int fromId, int toId);
    }

    public class PathPoint
    {
        public int Id;
        public Vector3 WorldPos;
    }

}

