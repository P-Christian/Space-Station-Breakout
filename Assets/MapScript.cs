using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public GameObject Floor3;
    void Update()
    {
        if (Floor3.activeSelf != true)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Floor3.SetActive(true);
            }
        }
    }

    public void Exit()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
