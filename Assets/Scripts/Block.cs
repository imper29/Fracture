using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField]
    private int m_ContactLimit;
    [SerializeField]
    private UnityEvent m_OnContacted;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ball"))
            MakeContact();
    }

    public void MakeContact()
    {
        m_OnContacted.Invoke();
        if (--m_ContactLimit == 0)
            Destroy(gameObject);
    }
}
