using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class DialougeManager : MonoBehaviour
{
    [SerializeField] private GameObject dialougeParent;
    [SerializeField] private TMP_Text dialougeText;
    [SerializeField] private Button option1Button;
    [SerializeField] private Button option2Button;
    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField] private float  turnSpeed = 2f;
    [SerializeField] public List<AudioSource> audioSourcesToMute;
    [SerializeField] private GameObject player;

    private List<dialogueString> dialougeList;
    [Header("Player")]
    [SerializeField] public NewBehaviourScript playerController;
    private Transform playerCamera;
     private int currentDialougeIndex = 0;
     public NewBehaviourScript playerMove;

     private void Start()
     {
        dialougeParent.SetActive(false);
        playerCamera = Camera.main.transform;
        player = GameObject.FindGameObjectWithTag("Player");
        playerMove = player.GetComponent<NewBehaviourScript>();
     }

     public void DialougeStart(List<dialogueString> textToPrint, Transform NPC)
     {
        dialougeParent.SetActive(true);
        playerController.enabled = false;
        foreach(var audioSource in audioSourcesToMute)
        {
            audioSource.volume = 0.01f;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        StartCoroutine(TurnCameraTowardsNPC(NPC));

        dialougeList = textToPrint;
        currentDialougeIndex = 0;

        DisableButtons();

        StartCoroutine(PrintDialouge());      


     }

     private void DisableButtons()
     {
        option1Button.interactable = false;
        option2Button.interactable = false;

        option1Button.GetComponentInChildren<TMP_Text>().text = "...";
        option2Button.GetComponentInChildren<TMP_Text>().text = "...";

     }

     private IEnumerator TurnCameraTowardsNPC(Transform NPC)
     {
        Quaternion startRotation = playerCamera.rotation;
        Quaternion targetRotation = Quaternion. LookRotation(NPC.position = playerCamera.position);

        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            playerCamera.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime);
            yield return null;
        }

        playerCamera.rotation = targetRotation;
     }

     private bool optionSelected = false;
     private IEnumerator PrintDialouge()
        {
            while(currentDialougeIndex < dialougeList.Count)
            {
                dialogueString line = dialougeList[currentDialougeIndex];

                line.startDialougeEvent?.Invoke();

                if(line.isQuestion)
                {
                    yield return StartCoroutine(TypeText(line.text));

                    option1Button.interactable = true;
                    option2Button.interactable = true;

                    option1Button.GetComponentInChildren<TMP_Text>().text = line.choiceOption1;
                    option2Button.GetComponentInChildren<TMP_Text>().text = line.choiceOption2;

                    option1Button.onClick.AddListener(() => HandleOptionSelected(line.option1Indexjump));
                    option2Button.onClick.AddListener(() => DialougeStop());

                    yield return new WaitUntil(() => optionSelected);
                    
                }
                else
                {
                    yield return StartCoroutine(TypeText(line.text));
                }
                line.endDialougeEvent?.Invoke();
                optionSelected = false;
            }
            DialougeStop();
        }
        private void HandleOptionSelected(int indexJump)
        {
            optionSelected = true;
            DisableButtons();

            currentDialougeIndex = indexJump;
        }   
        private IEnumerator TypeText(string text)
        {
            dialougeText.text = "";
            foreach(char letter in text.ToCharArray())
            {
                dialougeText.text += letter;
                yield return new WaitForSeconds(0.0000001f);
            }
            
            if(!dialougeList[currentDialougeIndex].isQuestion)
            {
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            }
            if(dialougeList[currentDialougeIndex].isEnd)
            {
                DialougeStop();
            }

            currentDialougeIndex ++;
        }

        public void DialougeStop()
        {
            StopAllCoroutines();
            dialougeText.text = "";
            dialougeParent.SetActive(false);

            playerController.enabled = true;
            playerController.canMove = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }


}
