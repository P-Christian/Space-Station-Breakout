using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBuff : MonoBehaviour
{
    public GameObject myObject;
    public Vector3 rotation;
    BlueTimer timer;
    [SerializeField] GameObject timerUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            timerUI.SetActive(true);
            timer = GameObject.FindGameObjectWithTag("BlueTimeTag").GetComponent<BlueTimer>();
            timer.SetTime(16f);
            NewBehaviourScript playerScript = other.GetComponent<NewBehaviourScript>();

            if (playerScript != null)
            {
                playerScript.UpdateMovementSpeeds(newWalkSpeed: 20f, newRunSpeed: 25f);
            }

            gameObject.SetActive(false);
        }
        
    }
    void Update()
    {
        this.transform.Rotate(rotation * 10 * Time.deltaTime);
    }
}
