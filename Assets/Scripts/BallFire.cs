using UnityEngine;
using UnityEngine.Events;

public class BallFire : MonoBehaviour
{
    private bool m_FireAlive;
    private float m_FireExtinguishTime;
    [SerializeField]
    private UnityEvent m_OnFireStopped;
    [SerializeField]
    private UnityEvent m_OnFireStarted;
    [SerializeField]
    private UnityEvent<float> m_OnFireDurationChanged;

    private void FixedUpdate()
    {
        if (m_FireAlive)
        {
            if (m_FireExtinguishTime <= Time.time)
            {
                m_FireAlive = false;
                m_OnFireDurationChanged.Invoke(0.0f);
                m_OnFireStopped.Invoke();
            }
            else
            {
                m_OnFireDurationChanged.Invoke(m_FireExtinguishTime - Time.time);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var fire = collision.collider.GetComponent<BallFireStarter>();
        if (fire)
            Ignite(fire.Duration);
        var ball = collision.collider.GetComponent<BallFire>();
        if (ball)
            Ignite(ball.m_FireExtinguishTime - Time.time);
        if (m_FireAlive && collision.gameObject.tag == "Player")
            Destroy(collision.gameObject);
    }

    private void Ignite(float time)
    {
        if (time <= 0f)
            return;

        m_FireExtinguishTime = Mathf.Max(m_FireExtinguishTime, Time.time + time);
        if (!m_FireAlive && m_FireExtinguishTime > Time.time)
        {
            m_FireAlive = true;
            m_OnFireStarted.Invoke();
            m_OnFireDurationChanged.Invoke(m_FireExtinguishTime - Time.time);
        }
    }
}
