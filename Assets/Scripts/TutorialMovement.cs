using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialMovement : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    public string interactText = "W A S D  to move";

    private void OnTriggerStay(Collider other)
    {
        tutorialText.text = interactText;
        tutorialText.gameObject.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        tutorialText.gameObject.SetActive(false);
    }
}
