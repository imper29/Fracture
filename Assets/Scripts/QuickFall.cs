using UnityEngine;

public class QuickFall : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_Body;

    private void FixedUpdate()
    {
        if (m_Body.velocity.y < 0f)
            m_Body.AddForce(Physics2D.gravity * 0.5f);
    }
}
