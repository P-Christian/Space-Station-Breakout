using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    PlayerInv playerInventory;

    public string targetSceneName;
    void Start()
    {
        // Attempt to find the PlayerInv component in the scene
        playerInventory = FindObjectOfType<PlayerInv>();

        if (playerInventory == null)
        {
            Debug.LogError("Player Inventory not found!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerInventory != null && playerInventory.NumOfComponents == 8)
            {
                Debug.Log("Door can be opened!");
                SceneManager.LoadScene(targetSceneName);
                StaticData.valueToKeep = "0";
                PlayerPrefs.DeleteAll();
            } else {
                    Debug.Log("You need at least 8 components to open this door.");
                }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Player exited the trigger zone.");
        }
    }
}
