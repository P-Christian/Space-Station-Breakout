using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class NewBehaviourScript : MonoBehaviour
{
    Animator animator;
    float velocity = 0.0f;
    public Camera playerCamera;
    public float walkSpeed = 15f;
    public float runSpeed = 20f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public AudioSource walkSound;
    public AudioSource runSound;
    public AudioSource components;
    public AudioSource buffs;
    public float lookSpeed = 2f;
    public float lookXLimit = 90f;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    public bool canMove = true;
    public float walkVolume = 0.25f;
    public float runVolume = 0.35f;

    CharacterController characterController;
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Components")
        {
            components.Play();
        }

        if (other.gameObject.tag == "RedTag" || other.gameObject.tag == "BlueTag" || other.gameObject.tag == "YellowTag" || other.gameObject.tag == "GreenTag")
        {
            buffs.Play();
        }

        
    }

    void Update()
    {
        #region Handles Animation
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        if (forwardPressed)
        {
            animator.SetBool("isWalking", true);
        }
        if (!forwardPressed)
        {
            animator.SetBool("isWalking", false);
        }

        if (forwardPressed && runPressed)
        {
            animator.SetBool("isRunning", true);
        }
        if (!forwardPressed || !runPressed)
        {
            animator.SetBool("isRunning", false);
        }
        #endregion

        #region Handles Movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if(canMove)
        {
            if(canMove && !(curSpeedX != 0 || curSpeedY != 0))
            {
                Debug.Log("Playing sound");
                walkSound.Play();
                walkSound.volume = walkVolume;
            }

            if(!Input.GetKey(KeyCode.LeftShift))
            {
                Debug.Log("Playing run!!");
                runSound.Play();
                runSound.volume = runVolume;
            }
        }
        
        
        if(runPressed)
        {
            walkVolume = 0.01f;
            walkSound.volume = walkVolume;
            runVolume = 0.35f;
            runSound.volume = runVolume;
        }
        else
        {
            walkVolume = 0.25f;
            walkSound.volume = walkVolume;
        }
        #endregion

        #region Handles Jumping 
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        #endregion

        #region Handles Rotation
        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove){
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        #endregion
    }

    public void UpdateMovementSpeeds(float newWalkSpeed, float newRunSpeed)
    {
        walkSpeed = newWalkSpeed;
        runSpeed = newRunSpeed;
    }
}