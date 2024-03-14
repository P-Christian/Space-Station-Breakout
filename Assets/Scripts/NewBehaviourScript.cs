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
    public AudioSource soundy;


    public float lookSpeed = 2f;
    public float lookXLimit = 90f;


    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;


    CharacterController characterController;
    void Start()
    {
        soundy = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        #region Handles Animation
        bool forwardPressed = Input.GetKey("w");
        bool runPressed =Input.GetKey("left shift");
        if (forwardPressed)
        {
            animator.SetBool("isWalking", true);
            
        }
        if (!forwardPressed)
        {
            animator.SetBool("isWalking", false);
            if(soundy !=null)
            {
                soundy.Play();
            }
        }

        if (forwardPressed && runPressed){
            animator.SetBool("isRunning", true);
        }
        if (!forwardPressed || !runPressed){
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

        if (canMove)
        {
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
