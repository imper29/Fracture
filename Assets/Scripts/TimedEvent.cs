using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimedEvent : MonoBehaviour
{
    [SerializeField]
    private float m_Time;
    [SerializeField]
    private UnityEvent m_Event;

    private void Start()
    {
        StartCoroutine(Timeout());
    }

    private IEnumerator Timeout()
    {
        yield return new WaitForSeconds(m_Time);
        m_Event.Invoke();
    }
}
