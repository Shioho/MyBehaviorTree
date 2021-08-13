using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtBezier : MonoBehaviour
{
    public bool autoUpdate = true; // 修改值时更新曲线
    [Tooltip("次数")]
    public int n; // 次数
    public enum Type
    {
        Bezier,
        BSpline
    }
    public Type drawType = Type.Bezier; // 绘制曲线的方式
    public Color curveColor; // 曲线的颜色
    [SerializeField]
    private List<Vector2> points = new List<Vector2>(); // 用于绘制的点
    [Range(1, 50)]
    public int part = 20; // 分段
    public List<Vector2> controlPoints = new List<Vector2>(); // 控制点

    public void Draw()
    {
        switch (drawType)
        {
            case Type.Bezier:
                CaculateBezier();
                break;
            case Type.BSpline:
                CaculateBSpline();
                break;
            default:
                break;
        }
    }

    private void OnDrawGizmosSelected()
    {
        
    }

    private void OnDrawGizmos()
    {
        // 画控制点
        Gizmos.color = Color.red;
        if (controlPoints.Count > 0)
        {
            for (int i = 0; i < controlPoints.Count; i++)
            {
                Gizmos.DrawSphere(controlPoints[i], 0.1f);
            }
        }
        if (controlPoints.Count > 0)
        {
            for (int i = 0; i < controlPoints.Count - 1; i++)
            {
                Gizmos.DrawLine(controlPoints[i], controlPoints[i + 1]);
            }
        }

        // 画曲线
        Gizmos.color = curveColor;
        if (points.Count > 0)
        {
            for (int i = 0; i < points.Count - 1; i++)
            {
                Gizmos.DrawLine(points[i], points[i + 1]);
            }
        }
    }

    public void CaculateBSpline()
    {
        points.Clear();
        for (int i = 0; i <= part; i++)
        {
            points.Add(BSpline(i / (float)part, n, controlPoints));
        }
    }
    public void CaculateBezier()
    {
        points.Clear();
        for (int i = 0; i <= part; i++)
        {
            points.Add(Bezier(i / (float)part, n, controlPoints));
        }
    }

    // 贝塞尔曲线
    public Vector2 Bezier(float t, int n, List<Vector2> cPoints)
    {
        Vector2 res = new Vector2();

        for (int i = 0; i <= n; i++)
        {
            float temp = BaseBezier(t, i, n);
            res.x += cPoints[i].x * temp;
            res.y += cPoints[i].y * temp;
        }

        return res;
    }
    // B 样条曲线
    public Vector2 BSpline(float t, int n, List<Vector2> cPoints)
    {
        Vector2 res = new Vector2();

        for (int l = 0; l <= n; l++)
        {
            float temp = BaseBSpline(t, l, n);
            res.x += cPoints[l].x * temp;
            res.y += cPoints[l].y * temp;
        }

        return res;
    }

    // B样条基函数
    public float BaseBSpline(float t, int l, int n)
    {
        float res = 0;
        for (int j = 0; j <= n - l; j++)
        {
            res += Mathf.Pow(-1, j) *
                Mathf.Pow(t + n - l - j, n) *
                Fa(n + 1) / (Fa(j) * Fa(n + 1 - j));
        }
        return res / Fa(n);
    }

    // 贝塞尔基函数
    public float BaseBezier(float t, int i, int n)
    {
        float res = Fa(n) * Mathf.Pow(t, i) * Mathf.Pow(1 - t, n - i) / (Fa(i) * Fa(n - i));
        return res;
    }

    // Factorial 阶乘
    public int Fa(int i)
    {
        int res = 1;
        for (int j = i; j > 1; j--)
        {
            res *= j;
        }
        return res;
    }

}
