using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    private bool isCursorVisible = false;

    void Start()
    {
        isCursorVisible = true;
    }

    private void Update()
    {
        ShowCursor();
    }
    void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isCursorVisible = true;
    }
}
