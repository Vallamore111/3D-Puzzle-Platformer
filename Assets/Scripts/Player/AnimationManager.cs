using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator playerAnimator;
    private int xVelocity;
    private int yVelocity;
    private int isJumping;

    private float dampTime = 0.1f;
    private Rigidbody playerRigidbody;
    private InputManager inputManager;



    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        inputManager = GetComponent<InputManager>();
    }


    private void Start()
    {
        xVelocity = Animator.StringToHash("xMovement");
        yVelocity = Animator.StringToHash("yMovement");
        isJumping = Animator.StringToHash("isJumping");
    }


    public void UpdateLocomotionAnimation()
    {
        float animVelocityX = inputManager.inputDirection.x * playerRigidbody.velocity.magnitude;
        float animVelocityY = inputManager.inputDirection.z * playerRigidbody.velocity.magnitude;

        playerAnimator.SetFloat(xVelocity, animVelocityX, dampTime, Time.deltaTime);
        playerAnimator.SetFloat(yVelocity, animVelocityY, dampTime, Time.deltaTime);
    }


    public void TriggerJumpAnimation() => playerAnimator.SetTrigger(isJumping);
}
