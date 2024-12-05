using TMPro;
using UnityEngine;

public class ScoreRenderer : MonoBehaviour
{
    [SerializeField]
    private string m_Format;
    [SerializeField]
    private TextMeshProUGUI m_Text;

    public void UpdateScore(Vector2 position, int score)
    {
        m_Text.text = string.Format(m_Format, score);
    }
}
