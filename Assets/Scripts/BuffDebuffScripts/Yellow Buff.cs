using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBuff : MonoBehaviour
{
    public GameObject myObject;
    public Vector3 rotation;
    public Behaviour item1;
    
    YellowTimer timer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer = GameObject.FindGameObjectWithTag("YellowTimeTag").GetComponent<YellowTimer>();
            timer.SetTime(46f);
            item1.enabled = true;
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        this.transform.Rotate(rotation * 10 * Time.deltaTime);
    }
    public void SetBehavior(string noOutline)
    {
        if (noOutline == "true")
        {
            item1.enabled = false;
            
        }
    }
}
