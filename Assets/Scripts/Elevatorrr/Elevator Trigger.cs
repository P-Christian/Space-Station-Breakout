using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlatform : MonoBehaviour
{
    PlatformMovement platform;
    private Transform playerTransform;
    private bool inRange = false;


    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        platform = GetComponent<PlatformMovement>();
       
    }

    private void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inRange = true;
            Debug.Log("Yamete");
        }
        
    }
    private void OnTriggerExit (Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inRange = true;
            Debug.Log("Kudasai");
        }
        
    }

    private void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.F))
        {
             platform.canMove = true;
             Debug.Log("Hentai");
    }
}
}