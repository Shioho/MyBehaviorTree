using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ExtBezier))]
[DisallowMultipleComponent]
public class ExtBezierInspector : Editor
{

    ExtBezier drawBAB;

    void OnEnable()
    {
        //获取当前编辑自定义Inspector的对象
        drawBAB = (ExtBezier)target;
    }
    public override void OnInspectorGUI()
    {
        // 如果面板上有值改变返回值true
        if (DrawDefaultInspector())
        {
            // 确保次数要小于控制点的个数
            if (drawBAB.n > drawBAB.controlPoints.Count - 1)
            {
                drawBAB.n = drawBAB.controlPoints.Count - 1;
                Debug.LogWarning("次数要小于控制点的个数");
            }

            // 如果是改变值时也生成就生成
            if (drawBAB.autoUpdate)
            {
                drawBAB.Draw();
            }
        }
        // 点下Generate按钮就生成
        if (GUILayout.Button("Generate"))
        {
            drawBAB.Draw();
        }

    }

}
