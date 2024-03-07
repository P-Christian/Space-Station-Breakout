using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DialougeTrigger : MonoBehaviour
{
    [SerializeField] private List<dialogueString> dialougeStrings = new List<dialogueString>();
    [SerializeField] private Transform NPCTransform;
    
    private bool hasSpoken = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !hasSpoken)
        {
            other.gameObject.GetComponent<DialougeManager>().DialougeStart(dialougeStrings, NPCTransform);
            hasSpoken = true;
        }
    }
}

[System.Serializable]
public class dialogueString
{
    public string text;
    public bool isEnd;


    [Header("Branch")]
    public bool isQuestion;
    public string choiceOption1;
    public string choiceOption2;
    public int option1Indexjump;
    public int option2Indexjump;

    [Header("Triggered Events")]
    public UnityEvent startDialougeEvent;
    public UnityEvent endDialougeEvent;
}
