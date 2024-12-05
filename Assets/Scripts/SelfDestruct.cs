using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField]
    private float m_Lifetime;
    [SerializeField]
    private UnityEvent m_OnDestroyed;

    private void Start()
    {
        StartCoroutine(DestroySelf(m_Lifetime));
    }
    private void OnDisable()
    {
        try
        {
            m_OnDestroyed.Invoke();
        }
        catch
        {

        }
    }

    private IEnumerator DestroySelf(float delay)
    {
        float timeShrink = 0.2f;
        yield return new WaitForSeconds(delay - timeShrink);
        float timeStart = Time.time;
        float timeEnd = Time.time + timeShrink;
        Vector3 scale = transform.localScale;
        while (timeEnd > Time.time)
        {
            float mag = Mathf.InverseLerp(timeEnd, timeStart, Time.time);
            transform.localScale = scale * mag;
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
