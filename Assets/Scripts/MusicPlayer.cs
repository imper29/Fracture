using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField]
    private Music[] m_Music;
    [SerializeField]
    private AudioSource[] m_TrackPlayers;
    
    private Music m_Active;
    private float m_TimeEnd;
    private float m_TimeStart;

    private void Update()
    {
        if (Time.time >= m_TimeEnd)
        {
            m_Active = m_Music[Random.Range(0, m_Music.Length)];
            m_TimeEnd = Time.time + m_Active.Duration;
            m_TimeStart = Time.time;
            for (int i = 0; i < m_Active.Tracks.Length; i++)
            {
                m_TrackPlayers[i].clip = m_Active.Tracks[i];
                m_TrackPlayers[i].Play();
            }
        }

        float lerp = Mathf.InverseLerp(m_TimeStart, m_TimeEnd, Time.time);
        for (int i = 0; i < m_Active.Volumes.Length; i++)
            m_TrackPlayers[i].volume = m_Active.Volumes[i].Evaluate(lerp);
    }
}
