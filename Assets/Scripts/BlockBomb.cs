using UnityEngine;

public class BlockBomb : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Prefab;
    static Vector3[] s_Locations = new Vector3[]
    {
        new(1,-1,0),
        new(-1,-1,0),
        new(0,-1,0),
    };
    static Vector3[] s_Velocities = new Vector3[]
    {
        new(5, 5, 0),
        new(-5, 5, 0),
        new(0, 1, 0),
    };
    
    public void ThrowBombs(int count)
    {
        for (int i = 0; i < count; ++i)
        {
            Vector3 location = s_Locations[i % s_Locations.Length];
            Vector3 position = transform.position + new Vector3(location.x, location.y, 0f);
            Quaternion rotation = Quaternion.AngleAxis(location.z, Vector3.forward);
            var bomb = Instantiate(m_Prefab, position, rotation);
            var body = bomb.GetComponent<Rigidbody2D>();
            Vector3 velocity = s_Velocities[i % s_Velocities.Length];
            body.velocity = velocity;
            body.angularVelocity = velocity.z;
        }
    }
}
