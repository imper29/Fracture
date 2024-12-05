using UnityEngine;
using UnityEngine.Events;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_Body;
    [SerializeField]
    private StatBool m_JumpEnabled;
    [SerializeField]
    private StatFloat m_JumpStrength;
    [SerializeField]
    private int m_JumpCountMax;
    [SerializeField]
    private UnityEvent m_OnJumped;

    private int m_JumpCount;

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && m_JumpEnabled.Value && m_JumpCount > 0)
        {
            --m_JumpCount;
            m_Body.velocity = new(m_Body.velocity.x, 0f);
            m_Body.AddForce(new(0, m_JumpStrength.Value), ForceMode2D.Impulse);
            m_OnJumped.Invoke();
        }
    }

    public void JumpCountReset()
    {
        m_JumpCount = m_JumpCountMax;
    }
}
