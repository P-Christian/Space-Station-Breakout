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
                instructionsOne.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            instructionsOne.SetActive(false);
        }

        if (instructionsTwo.activeSelf != true)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                instructionsTwo.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            instructionsTwo.SetActive(false);
        }
    }
}