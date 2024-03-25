using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsScript : MonoBehaviour
{
    public GameObject instructionsOne;
    public GameObject instructionsTwo;

    void Update()
    {

        if (instructionsOne.activeSelf != true)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                instructionsOne.SetActive(true);
            }
        }
    }

    public void Exit()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
