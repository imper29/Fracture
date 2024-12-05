using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneModiifer : MonoBehaviour
{
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
