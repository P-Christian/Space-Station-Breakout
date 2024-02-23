using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public GameObject myObject; // Reference to the GameObject you want to manipulate
    private Transform playerTransform;
    private bool inRange = false;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        myObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
            myObject.SetActive(false);
        }
    }

    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            myObject.SetActive(true);
        }
        if (inRange && Input.GetKeyDown(KeyCode.R))
        {
            myObject.SetActive(false);
        }
    }
}
