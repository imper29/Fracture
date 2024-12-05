using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_Body;
    [SerializeField]
    private StatBool m_WalkEnabled;
    [SerializeField]
    private StatFloat m_WalkSpeed;
    [SerializeField]
    private StatFloat m_WalkAccel;

    private void FixedUpdate()
    {
        float axis = Input.GetAxisRaw("Horizontal");
        float target = m_WalkSpeed.Value * axis;
        float current = m_Body.velocity.x;
        float difference = current - target;
        float impulse = 0f;
        if (target > current)
            impulse = Mathf.Min(m_WalkAccel.Value, Mathf.Abs(difference));
        else if (target < current)
            impulse = -Mathf.Min(m_WalkAccel.Value, Mathf.Abs(difference));
        m_Body.AddForce(new(impulse, 0), ForceMode2D.Impulse);
    }
}
