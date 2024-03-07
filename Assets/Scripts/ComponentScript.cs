using System.Collections;
using UnityEngine;

public class ComponentScript : MonoBehaviour
{
    public GameObject myObject;
    public Vector3 rotation;
    public string interactText = "Press E to interact";
    private Transform playerTransform; // Reference to the player's transform
    private bool inRange = false;
    private bool collected;
    [SerializeField] private string id;

    private PlayerInv playerInventory; // Reference to the PlayerInv script

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Find the player's transform
        LoadState(); // Load the state when the component starts
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInv otherPlayerInventory = other.GetComponent<PlayerInv>();
            if (otherPlayerInventory != null && !collected)
            {
                SaveState();
                collected = true;
                gameObject.SetActive(false);
                otherPlayerInventory.ComponentsCollected();
            }

            if (other.CompareTag("Player"))
            {
                inRange = true;
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    void Update()
    {
        this.transform.Rotate(rotation * 2 * Time.deltaTime);
    }

    public void SaveState()
    {
        // Save the component ID in PlayerPrefs
        PlayerPrefs.SetString(id, id);
        PlayerPrefs.Save();
    }

    public void LoadState()
    {
        // Check if the component ID is present in PlayerPrefs
        if (PlayerPrefs.HasKey(id))
        {
            collected = true;
            gameObject.SetActive(false);
        }
    }
}