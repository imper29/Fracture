using UnityEngine;
using UnityEngine.Events;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField]
    private UnityEvent m_OnPlayerKilled;

    public void KillPlayer()
    {
        foreach (var listener in FindObjectsOfType<PlayerDeath>())
            listener.m_OnPlayerKilled.Invoke();
    }
}
