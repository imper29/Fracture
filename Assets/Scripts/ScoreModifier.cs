using UnityEngine;

public class ScoreModifier : MonoBehaviour
{
    public void GivePoints(int amount)
    {
        var manager = FindObjectOfType<ScoreManager>();
        if (manager)
            manager.GivePoints(transform.position, amount);
    }
    public  void GiveMultiplier(int amount)
    {
        var manager = FindObjectOfType<ScoreManager>();
        if (manager)
            manager.GiveMultiplier(transform.position, amount);
    }
}
