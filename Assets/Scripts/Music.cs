using UnityEngine;

[CreateAssetMenu]
public class Music : ScriptableObject
{
    [SerializeField]
    private AudioClip[] m_Tracks;
    [SerializeField]
    private AnimationCurve[] m_Volumes;

    public float Duration
    {
        get
        {
            float duration = 0f;
            for (int i = 0; i < m_Tracks.Length; ++i)
                if (duration < m_Tracks[i].length)
                    duration = m_Tracks[i].length;
            return duration;
        }
    }
    public AudioClip[] Tracks
    {
        get => m_Tracks;
    }
    public AnimationCurve[] Volumes
    {
        get => m_Volumes;
    }
}
