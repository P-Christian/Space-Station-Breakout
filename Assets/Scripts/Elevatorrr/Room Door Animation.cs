using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    Animator animator;
    private Transform playerTransform;
    private bool inRange = false;
    private bool open = false;
    public AudioSource opin;
    public AudioSource klos;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Sup");
            inRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Bye");
            inRange = false;
        }
    }

    private void Update()
    {
        
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!open)
            {
                animator.SetBool("Enter", true);
                Debug.Log("Open");
                open = true;
                opin.Play();
            }
            else
            {
                animator.SetBool("Enter", false);
                Debug.Log("Close");
                open = false;
                klos.Play();
            }
            
        }
    }
}