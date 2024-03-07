using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBuff : MonoBehaviour
{
    public Vector3 rotation;
    public GameObject myObject;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthBar healthBar = GameObject.FindGameObjectWithTag("HealthTag").GetComponent<HealthBar>();
            healthBar.Heal(40);
            gameObject.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(rotation * 10 * Time.deltaTime);
    }
}
