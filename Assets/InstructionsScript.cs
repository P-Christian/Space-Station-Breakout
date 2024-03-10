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
        if (instructionsOne.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                instructionsOne.SetActive(false);
                instructionsTwo.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            instructionsOne.SetActive(false);
            instructionsTwo.SetActive(false);
        }
    }
}
