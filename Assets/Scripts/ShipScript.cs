using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipScript : MonoBehaviour
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
                Debug.Log("You can use the spaceship");
                SceneManager.LoadScene(targetSceneName);
                StaticData.valueToKeep = "0";
                PlayerPrefs.DeleteAll();
            }
            else
            {
                Debug.Log("You need at least 8 components to use the spaceship");
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
