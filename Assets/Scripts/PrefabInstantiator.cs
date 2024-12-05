using UnityEngine;

public class PrefabInstantiator : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Prefab;

    public void Instantiate()
    {
        Instantiate(m_Prefab, transform.position, transform.rotation);
    }
}
