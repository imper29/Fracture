using System.Collections.Generic;
using UnityEngine;

public class StatBool : MonoBehaviour
{
    private Dictionary<string, bool> m_Flags = new();

    public bool Value
    {
        get
        {
            foreach (var flag in m_Flags.Values)
                if (!flag)
                    return false;
            return true;
        }
    }

    public void SetTrue(string flag)
    {
        m_Flags[flag] = true;
    }
    public void SetFalse(string flag)
    {
        m_Flags[flag] = false;
    }
}
