using System;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    [SerializeField]
    private string m_Directory;

    private void Update()
    {

        if (Application.isEditor && Input.GetKeyDown(KeyCode.F2))
        {
            ScreenCapture.CaptureScreenshot($"{m_Directory}/{Guid.NewGuid():N}.png");
        }
    }
}
