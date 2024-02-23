using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    public GameObject myObject;

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
            myObject.SetActive(true);
        }
    }

    void Update()
    {
       
    }
}
