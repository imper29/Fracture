using UnityEngine;
using UnityEngine.Events;

public class Renormalizer : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve m_Curve;
    [SerializeField]
    private UnityEvent<float> m_Event;

    public void Refresh(float value)
    {
        m_Event.Invoke(m_Curve.Evaluate(value));
    }
}
