using UnityEngine;

public class TimeModifier : MonoBehaviour
{
    public float TimeScale
    {
        get => Time.timeScale;
        set => Time.timeScale = value;
    }
}
