using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class IsTouching : MonoBehaviour
{
    [SerializeField]
    private LayerMask m_Layers;
    [SerializeField]
    private UnityEvent m_OnCollisionExit;
    [SerializeField]
    private UnityEvent m_OnCollisionEnter;
    private int m_TouchCount;

    private void Awake()
    {
        m_OnCollisionExit.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if ((m_Layers & (1 << collider.gameObject.layer)) != 0)
            if (++m_TouchCount == 1)
                m_OnCollisionEnter.Invoke();
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if ((m_Layers & (1 << collider.gameObject.layer)) != 0)
            if (--m_TouchCount == 0)
                m_OnCollisionExit.Invoke();
    }
}
