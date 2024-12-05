using UnityEngine;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private string m_PauseKey;
    [SerializeField]
    UnityEvent m_OnPaused;
    [SerializeField]
    UnityEvent m_OnUnpaused;

    private bool m_Paused;

    private void Update()
    {
        if (Input.GetButtonDown(m_PauseKey))
        {
            m_Paused = !m_Paused;
            if (m_Paused)
                m_OnPaused.Invoke();
            else
                m_OnUnpaused.Invoke();
        }
    }
}
