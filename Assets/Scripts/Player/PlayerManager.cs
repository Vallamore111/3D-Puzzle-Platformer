using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerRaycast playerRaycast;
    private PlayerLocomotion playerLocomotion;
    private InputManager inputManager;
    private AnimationManager animationManager;


    private void Awake()
    {
        playerRaycast = GetComponent<PlayerRaycast>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        inputManager = GetComponent<InputManager>();
        animationManager = GetComponent<AnimationManager>();
    }


    private void Update()
    {
        playerRaycast.HandleAllRaycasts();
        inputManager.HandleAllInputs();
        animationManager.UpdateLocomotionAnimation();
    }


    private void FixedUpdate()
    {
        playerLocomotion.HandleAllMovement();
    }
}
