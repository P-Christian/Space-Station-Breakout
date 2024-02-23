using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlesCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform playerTransform;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Alien").transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with " + gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
