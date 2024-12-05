using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CameraMoverConstraint : MonoBehaviour
{
    private BoxCollider2D m_Collider;

    private void Awake()
    {
        m_Collider = GetComponent<BoxCollider2D>();
    }

    public Vector2 Min
    {
        get => m_Collider.bounds.min;
    }
    public Vector2 Max
    {
        get => m_Collider.bounds.max;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var camera = FindObjectOfType<CameraMover>();
            camera.AddConstraint(this);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var camera = FindObjectOfType<CameraMover>();
            camera.RemoveConstraint(this);
        }
    }
    private void OnDrawGizmos()
    {
        var bounds = GetComponent<BoxCollider2D>().bounds;
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(bounds.center, bounds.size);
        Gizmos.color = Color.white;
    }
}
