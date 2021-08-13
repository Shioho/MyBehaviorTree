using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Shioho
{
    [CustomEditor(typeof(AStarPathPlan))]
    [DisallowMultipleComponent]
    public class AStarPathPlanInspector : Editor
    {

        private Transform _transform;
        private Vector2 _cellSize;
        private Vector2 _mapRowColumn;


        private SerializedProperty _mapCellSize;
        private SerializedProperty _mapRowColumnSize;

        private void OnEnable()
        {
            var script = target as AStarPathPlan;
            _transform = script.gameObject.transform;
            _mapCellSize = serializedObject.FindProperty("_mapCellSize");
            _mapRowColumnSize = serializedObject.FindProperty("_mapRowColumnSize");
            OnUpdateData();
        }

        public override void OnInspectorGUI()
        {
            var script = target as AStarPathPlan;

            GUILayout.BeginVertical("box");
            GUILayout.Label("MapPathSetting", new GUIStyle
            {
                fontSize = 20,
                fontStyle = FontStyle.Bold,
            });

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.PropertyField(_mapCellSize);
            EditorGUILayout.PropertyField(_mapRowColumnSize);


            if (EditorGUI.EndChangeCheck())
            {
                OnUpdateData();
            }

            GUILayout.EndVertical();


            serializedObject.ApplyModifiedProperties();

        }

        private void OnUpdateData()
        {
            _cellSize = _mapCellSize.vector2Value;
            _mapRowColumn = _mapRowColumnSize.vector2Value;
        }

        private void OnSceneGUI()
        {
            //drawMap
            for (int i = 0; i < _mapRowColumn.x + 1; i++)
            {
                for (int j = 0; j < _mapRowColumn.y + 1; j++)
                {
                    var startPos = _transform.position + new Vector3(i * _cellSize.x, j * _cellSize.y);
                    var toPosX = _transform.position + new Vector3((i + 1) * _cellSize.x, j * _cellSize.y);
                    var toPosY = _transform.position + new Vector3(i * _cellSize.x, (j + 1) * _cellSize.y);

                    if (i < _mapRowColumn.x) 
                    {
                        Debug.DrawLine(startPos, toPosX);
                    }
                    if (j < _mapRowColumn.y) 
                    {
                        Debug.DrawLine(startPos, toPosY);
                    }

                    int id = i * (int)(_mapRowColumn.y) + j;
                    

                }
            }



        }



    }
}