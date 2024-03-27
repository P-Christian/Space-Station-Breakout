using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    private Transform playerTransform;
    Animator animator;
    public AudioSource open;
    public AudioSource close;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            animator.SetBool("Enter", true);
            open.Play();
        }
    }
     public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            animator.SetBool("Enter", false);
            close.Play();
        }
    }
}
