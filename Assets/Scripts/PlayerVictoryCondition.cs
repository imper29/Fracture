using UnityEngine;

public class PlayerVictoryCondition : MonoBehaviour
{
    private void OnEnable()
    {
        var victory = FindObjectOfType<PlayerVictory>();
        if (victory)
            victory.AddVictoryCondition();
    }
    private void OnDisable()
    {
        var victory = FindObjectOfType<PlayerVictory>();
        if (victory)
            victory.RemoveVictoryCondition();
    }
}
