using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Alien") 
        {
            print("Enter");
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Alien") 
        {
           print("Stay");
           FindObjectOfType<GameManager>().EndGame();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Alien") 
        {
            print("End");

        }

    }
}
