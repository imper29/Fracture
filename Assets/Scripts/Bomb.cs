using UnityEngine;
using UnityEngine.Events;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private bool m_ExplodesOnPlayerContact;
    [SerializeField]
    private float m_Radius;
    [SerializeField]
    private float m_Lifetime;
    private float m_Deathtime;
    [SerializeField]
    private GameObject m_Explosion;
    [SerializeField]
    private UnityEvent m_OnExplosion;

    private void Awake()
    {
        m_Deathtime = Time.time + m_Lifetime;
        if (m_Lifetime < 0f)
            m_Deathtime = float.PositiveInfinity;
    }
    private void Update()
    {
        if (m_Deathtime <= Time.time)
            Explode();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (m_ExplodesOnPlayerContact && collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            Explode();
    }

    public void Explode()
    {
        foreach (var collider in Physics2D.OverlapCircleAll(transform.position, m_Radius))
        {
            if (!collider.isTrigger && collider.gameObject != gameObject)
            {
                if (collider.gameObject.tag == "Player")
                    Destroy(collider.gameObject);
                else if (collider.gameObject.tag == "Block")
                    collider.GetComponent<Block>().MakeContact();
            }
        }
        if (m_Explosion)
            Instantiate(m_Explosion, transform.position, transform.rotation);
        m_OnExplosion.Invoke();
        Destroy(gameObject);
    }
}
