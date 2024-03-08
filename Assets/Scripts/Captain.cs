using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Captain : MonoBehaviour
{
    public string interactText = "Press E to interact";
    private Transform playerTransform; // Reference to the player's transform
    public GameObject myObject;

    public TextMeshProUGUI hintText;
    private bool inRange = false;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Find the player's transform
        hintText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            hintText.text = interactText;
            hintText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
            hintText.text = interactText;
            hintText.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            myObject.SetActive(true);
        }
    }
}
