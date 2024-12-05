using UnityEngine;

public class StatFloat : MonoBehaviour
{
    [SerializeField]
    private float m_Minimum;
    [SerializeField]
    private float m_Maximum;
    [SerializeField]
    private float m_Current;
    [SerializeField]
    private float m_CurrentBase;
    [SerializeField]
    private float m_CurrentBaseMultiplier = 1.0f;

    public float Minimum
    {
        get => m_Minimum;
        set => m_Minimum = value;
    }
    public float Maximum
    {
        get => m_Maximum;
        set => m_Maximum = value;
    }
    public float Current
    {
        get => m_Current;
        set => m_Current = value;
    }
    public float CurrentBase
    {
        get => m_CurrentBase;
        set => m_CurrentBase = value;
    }
    public float CurrentBaseMultiplier
    {
        get => m_CurrentBaseMultiplier;
        set => m_CurrentBaseMultiplier = value;
    }
    public float Value
    {
        get => Mathf.Clamp(Current + CurrentBase * CurrentBaseMultiplier, Minimum, Maximum);
    }

    public void ChangeMinimum(float amount)
    {
        m_Minimum += amount;
    }
    public void ChangeMaximum(float amount)
    {
        m_Maximum += amount;
    }
    public void ChangeCurrent(float amount)
    {
        m_Current += amount;
    }
    public void ChangeCurrentBase(float amount)
    {
        m_CurrentBase += amount;
    }
    public void ChangeCurrentBaseMultiplier(float amount)
    {
        m_CurrentBaseMultiplier += amount;
    }
}
