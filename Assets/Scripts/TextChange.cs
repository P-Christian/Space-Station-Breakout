using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextChange : MonoBehaviour
{
    public string hintText;
    public TextMeshProUGUI text;
    public Behaviour doorOutline;
    private Transform playerTransform;
    private bool inRange;
    [SerializeField] GameObject door;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inRange = true;
            text.text = hintText;
            doorOutline.enabled = true;
            text.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inRange = false;
            doorOutline.enabled = false;
            text.gameObject.SetActive(false);
        }
    }

    public void SetBehavior(string noOutline)
    {
        if (noOutline == "true")
        {
            doorOutline.enabled = false;

        }
    }
}
