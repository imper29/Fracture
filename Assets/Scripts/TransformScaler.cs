using UnityEngine;

public class TransformScaler : MonoBehaviour
{
    public void ScaleX(float amount)
    {
        var s = transform.localScale;
        s.x = amount;
        transform.localScale = s;
    }
    public void ScaleY(float amount)
    {
        var s = transform.localScale;
        s.y = amount;
        transform.localScale = s;
    }
    public void ScaleZ(float amount)
    {
        var s = transform.localScale;
        s.z = amount;
        transform.localScale = s;
    }
}
