using UnityEngine;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    AudioMixer m_AudioMixer;

    public void Quit()
    {
        Application.Quit();
    }
    public void UpdateVolume(string name, float value)
    {
        m_AudioMixer.SetFloat(name, Mathf.Lerp(-80f, 20f, Mathf.Sqrt(value)));
    }
    public void UpdateMaster(float value)
    {
        UpdateVolume("masterVolume", Mathf.Clamp(value, 0f, 1f));
    }
    public void UpdateMusic(float value)
    {
        UpdateVolume("musicVolume", Mathf.Clamp(value, 0f, 1f));
    }
    public void UpdatePop(float value)
    {
        UpdateVolume("popVolume", Mathf.Clamp(value, 0f, 1f));
    }
    public void UpdateDing(float value)
    {
        UpdateVolume("dingVolume", Mathf.Clamp(value, 0f, 1f));
    }
    public void UpdateBomb(float value)
    {
        UpdateVolume("bombVolume", Mathf.Clamp(value, 0f, 1f));
    }
}
