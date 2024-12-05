using UnityEngine;

public class PlayerKill : MonoBehaviour
{
    private void OnDestroy()
    {
        var death = FindObjectOfType<PlayerDeath>();
        if (death)
            death.KillPlayer();
    }
}
