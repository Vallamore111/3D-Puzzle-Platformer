using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    public bool isGrounded;
    public bool isSprinting;
    public bool onSlope;
    private float movementSpeed = 4f;
    private float turnSmoothTime = 0.15f;
    private float turnSmoothVelocity;
    private float jumpForce = 6f;
    private Vector3 moveDirection;
    private Rigidbody playerRigidbody;
    private InputManager inputManager;
    private AnimationManager animationManager;



    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        inputManager = GetComponent<InputManager>();
        animationManager = GetComponent<AnimationManager>();
    }



    public void HandleAllMovement()
    {
        if (inputManager.inputDirection.magnitude != 0)
        {
            HandleSprint();
            HandleMovement();
            HandleDirection();
        }
        else { DeceleratePlayer(); }
            
    }


    private void HandleMovement()
    {
        if (!isGrounded) return;
        if (playerRigidbody.velocity.magnitude > movementSpeed) return;

        if (!onSlope)
        { playerRigidbody.velocity = moveDirection * movementSpeed; }

        else
        { playerRigidbody.velocity = Vector3.ProjectOnPlane(moveDirection, PlayerRaycast.slopeHit.normal) * movementSpeed; }

        playerRigidbody.velocity = KeepVelocityForward();
    }


    private void HandleDirection()
    {
        if (!isGrounded) return;

        float targetAngle = Mathf.Atan2(inputManager.inputDirection.x, inputManager.inputDirection.z) * Mathf.Rad2Deg + CameraManager.instance.mainCameraObject.transform.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

        if (inputManager.inputDirection.z >= 0)
        { transform.rotation = Quaternion.Euler(0f, angle, 0f); }

        moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
    }


    private Vector3 KeepVelocityForward()
    {
        float yVelocityRB = playerRigidbody.velocity.y;
        Vector3 localVelocity = transform.InverseTransformDirection(playerRigidbody.velocity);

        localVelocity.x = 0;
        localVelocity.y = 0;

        Vector3 worldVelocity = transform.TransformDirection(localVelocity);
        worldVelocity.y = yVelocityRB;

        return worldVelocity;
    }


    private void HandleSprint()
    {
        if (isSprinting)
        { movementSpeed = 7f; }

        else {  movementSpeed = 4f; }
    }


    public void HandleJump()
    {
        if (!isGrounded) return;

        isGrounded = false;
        Vector3 jump = new Vector3(0, jumpForce, 0);
        playerRigidbody.AddForce(jump, ForceMode.Impulse);

        animationManager.TriggerJumpAnimation();
    }


    private void DeceleratePlayer()
    {
        Vector3 stopPosition = playerRigidbody.velocity;
        stopPosition.x = 0;
        stopPosition.z = 0;
        playerRigidbody.velocity = stopPosition;
    }
}
