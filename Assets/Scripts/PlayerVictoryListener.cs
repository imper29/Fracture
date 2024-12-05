using UnityEngine;
using UnityEngine.Events;

public class PlayerVictoryListener : MonoBehaviour
{
    [SerializeField]
    private UnityEvent m_Event;

    public UnityEvent Event
    {
        get => m_Event;
    }
}
