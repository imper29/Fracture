using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField]
    private float m_LookDistance;
    [SerializeField]
    private float m_SmoothTime;
    [SerializeField]
    private float m_MaxSpeed;
    [SerializeField]
    private float m_MaxDistance;
    [SerializeField]
    private Camera m_Camera;

    [SerializeField]
    private CameraMoverConstraint m_InitialConstraint;
    private HashSet<CameraMoverConstraint> m_Constraints = new();
    private GameObject m_Player;
    private Vector2 m_CurrentVelocity;

    private void Awake()
    {
        if (m_InitialConstraint)
            AddConstraint(m_InitialConstraint);
    }
    private void LateUpdate()
    {
        if (!m_Player)
            m_Player = GameObject.FindGameObjectWithTag("Player");
        if (m_Player)
        {
            Vector2 target = ApplyCursor(m_Player.transform.position);
            target = ApplyConstraints(target);
            target = ApplyDistanceLimit(target);
            transform.position = new(target.x, target.y, transform.position.z);
        }
    }

    private Vector2 ApplyCursor(Vector2 target)
    {
        Vector2 cursorPosition = (Vector2)Input.mousePosition / new Vector2(Screen.width, Screen.height);
        Vector2 cursorPositionNormalized = (cursorPosition - Vector2.one * 0.5f) * 2f;
        return target + cursorPositionNormalized * m_LookDistance;
    }
    private Vector2 ApplyConstraints(Vector2 target)
    {
        Vector2 viewCornerA = m_Camera.ViewportToWorldPoint(Vector3.zero);
        Vector2 viewCornerB = m_Camera.ViewportToWorldPoint(Vector3.one);
        Vector2 viewMin = Vector2.Min(viewCornerA, viewCornerB);
        Vector2 viewMax = Vector2.Max(viewCornerA, viewCornerB);
        Vector2 viewExtents = (viewMax - viewMin) * 0.5f;

        float distanceBest = float.PositiveInfinity;
        Vector2 targetBest = target;
        foreach (var constraint in m_Constraints)
        {
            Vector2 targetCurrent;
            Vector2 constraintMin = constraint.Min + viewExtents;
            Vector2 constraintMax = constraint.Max - viewExtents;

            if (constraintMin.x > constraintMax.x)
                targetCurrent.x = (constraintMin.x + constraintMax.x) * 0.5f;
            else
                targetCurrent.x = Mathf.Clamp(target.x, constraintMin.x, constraintMax.x);

            if (constraintMin.y > constraintMax.y)
                targetCurrent.y = (constraintMin.y + constraintMax.y) * 0.5f;
            else
                targetCurrent.y = Mathf.Clamp(target.y, constraintMin.y, constraintMax.y);

            var distanceCurrent = Vector2.Distance(targetCurrent, target);
            if (distanceCurrent < distanceBest)
            {
                targetBest = targetCurrent;
                distanceBest = distanceCurrent;
            }
        }

        return targetBest;
    }
    private Vector2 ApplyDistanceLimit(Vector2 target)
    {
        if (Vector2.Distance(transform.position, target) <= m_MaxDistance)
            target = Vector2.SmoothDamp(transform.position, target, ref m_CurrentVelocity, m_SmoothTime, m_MaxSpeed);
        return target;
    }

    public void AddConstraint(CameraMoverConstraint constraint)
    {
        m_Constraints.Add(constraint);
    }
    public void RemoveConstraint(CameraMoverConstraint constraint)
    {
        m_Constraints.Remove(constraint);
    }
}
