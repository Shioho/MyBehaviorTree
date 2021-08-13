using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shioho
{
    public class AStarPathPlan : MonoBehaviour, IPathPlan
    {
        [SerializeField]
        [Tooltip("单元格宽高")]
        private Vector2 _mapCellSize;
        [SerializeField]
        [Tooltip("单元格行列数")]
        private Vector2 _mapRowColumnSize;


        public List<Vector3> CalculatePath(int fromId, int toId)
        {
            throw new System.NotImplementedException();
        }
    }
}

