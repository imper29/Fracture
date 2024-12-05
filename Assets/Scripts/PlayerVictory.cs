using UnityEngine;

public class PlayerVictory : MonoBehaviour
{
    private int m_VictoryConditions;

    public void AddVictoryCondition()
    {
        ++m_VictoryConditions;
    }
    public void RemoveVictoryCondition()
    {
        if (--m_VictoryConditions == 0)
            foreach (var listener in FindObjectsOfType<PlayerVictoryListener>())
                listener.Event.Invoke();
    }
}
