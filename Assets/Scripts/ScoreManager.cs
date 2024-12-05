using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int m_Score;
    [SerializeField]
    private int m_Multiplier;
    [SerializeField]
    private float m_MultiplierTimeout;
    private float m_MultiplierTimeoutTime;
    [SerializeField]
    private int m_MultiplierBonus;
    private int m_MultiplierBonusCount;
    [SerializeField]
    private float m_MultiplierBonusTimeout;
    private float m_MultiplierBonusTimeoutTime;
    
    [SerializeField]
    private UnityEvent<Vector2,int> m_OnScoreChanged;
    [SerializeField]
    private UnityEvent<Vector2,int> m_OnScoreChangedDelta;
    [SerializeField]
    private UnityEvent<Vector2,int> m_OnMultiplierChanged;
    [SerializeField]
    private UnityEvent<Vector2, int> m_OnMultiplierChangedDelta;
    [SerializeField]
    private UnityEvent<float> m_OnMultiplierBonusChanged;
    [SerializeField]
    private UnityEvent<float> m_OnMultiplierChangedTimeout;
    [SerializeField]
    private UnityEvent<float> m_OnMultiplierBonusChangedTimeout;

    private void Update()
    {
        if (m_MultiplierBonusCount != 0 && Time.time >= m_MultiplierBonusTimeoutTime)
        {
            m_MultiplierBonusCount = 0;
            m_OnMultiplierBonusChanged.Invoke(0f);
            m_OnMultiplierBonusChangedTimeout.Invoke(0f);
        }
        else if (m_MultiplierBonusTimeoutTime > Time.time)
        {
            m_OnMultiplierBonusChangedTimeout.Invoke((m_MultiplierBonusTimeoutTime - Time.time) / m_MultiplierBonusTimeout);
        }

        if (m_Multiplier != 1 && Time.time >= m_MultiplierTimeoutTime)
        {
            var delta = 1 - m_Multiplier;
            m_Multiplier = 1;
            m_OnMultiplierChanged.Invoke(transform.position, m_Multiplier);
            m_OnMultiplierChangedDelta.Invoke(transform.position, delta);
            m_OnMultiplierBonusChanged.Invoke(0f);
            m_OnMultiplierChangedTimeout.Invoke(0f);
        }
        else if (m_MultiplierTimeoutTime > Time.time)
        {
            m_OnMultiplierChangedTimeout.Invoke((m_MultiplierTimeoutTime - Time.time) / m_MultiplierTimeout);
        }
    }

    public void GivePoints(Vector2 location, int amount)
    {
        amount *= m_Multiplier;
        if (amount == 0)
            return;

        m_Score += amount;
        m_OnScoreChanged.Invoke(location, m_Score);
        m_OnScoreChangedDelta.Invoke(location, amount);
        m_MultiplierBonusTimeoutTime = Time.time + m_MultiplierBonusTimeout;

        if (++m_MultiplierBonusCount == m_MultiplierBonus)
        {
            m_MultiplierBonusCount = 0;
            GiveMultiplier(location, 1);
        }
        m_OnMultiplierBonusChanged.Invoke(m_MultiplierBonusCount / (m_MultiplierBonus - 1f));
    }
    public void GiveMultiplier(Vector2 location, int amount)
    {
        if (amount == 0)
            return;
        if (m_Multiplier == 1 && amount != 1)
            --amount;
        m_Multiplier += amount;
        m_MultiplierTimeoutTime = Time.time + m_MultiplierTimeout;
        m_OnMultiplierChanged.Invoke(location, m_Multiplier);
        m_OnMultiplierChangedDelta.Invoke(location, amount);
    }
}
