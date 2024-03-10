using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBuff : MonoBehaviour
{
    // Start is called before the first frame update
    SlowDebuffTimer slowDebuff;
    public GameObject myObject;
    public Vector3 rotation;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            NewBehaviourScript playerScript = other.GetComponent<NewBehaviourScript>();
            slowDebuff = GameObject.FindGameObjectWithTag("SlowUI").GetComponentInChildren<SlowDebuffTimer>();

            if (playerScript != null)
            {
                slowDebuff.SetTime(0);
            }

            gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(rotation * 10 * Time.deltaTime);
    }
}
