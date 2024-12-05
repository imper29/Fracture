using UnityEngine;
using UnityEngine.Events;

public class PlayerStun : MonoBehaviour
{
    [SerializeField]
    private float m_Timeout = 0.0f;
    [SerializeField]
    private StatFloat m_TimeoutScale;
    [SerializeField]
    private StatFloat m_TimeoutMinimum;
    [SerializeField]
    private StatFloat m_TimeoutMaximum;
    [SerializeField]
    private UnityEvent<float> m_StunStarted;
    [SerializeField]
    private UnityEvent<float> m_StunStopped;
    [SerializeField]
    private UnityEvent<float> m_StunChanged;

    private void Update()
    {
        if (Application.isEditor && Input.GetKeyDown(KeyCode.Y))
            Stun(0.3f, 0.3f);
        if (m_Timeout > 0f)
        {
            m_Timeout = Mathf.Max(m_Timeout - m_TimeoutScale.Value * Time.deltaTime, 0f);
            m_StunChanged.Invoke(m_Timeout);
            if (m_Timeout <= 0f)
                m_StunStopped.Invoke(m_Timeout);
        }
    }

    public void Stun(float timeout, float timeoutOverlay)
    {
        float previous = m_Timeout;
        m_Timeout = Mathf.Clamp(Mathf.Max(m_Timeout, timeout) + timeoutOverlay, m_TimeoutMinimum.Value, m_TimeoutMaximum.Value);
        if (previous <= 0f && m_Timeout > 0f)
            m_StunStarted.Invoke(m_Timeout);
        m_StunChanged.Invoke(m_Timeout);
    }
}
