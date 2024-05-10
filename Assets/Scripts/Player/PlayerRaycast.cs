using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public Transform groundCheck;
    public Transform stepCheck;
    public LayerMask groundLayer;
    public LayerMask interactableLayer;
    private Vector3 originPoint;
    private Vector3 destinationPoint;
    private Rigidbody playerRigidbody;
    private InputManager inputManager;
    private PlayerLocomotion playerLocomotion;

    public static RaycastHit slopeHit;
    public static GameObject currentObject;



    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        inputManager = GetComponent<InputManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }


    public void HandleAllRaycasts()
    {
        CheckIfGrounded();
        CheckForStep();
        CastCursorRay();
    }


    public void CastCursorRay()
    {
        RaycastHit raycastHit;
        float castLength = 20f;

        SetVectorsForRay(castLength);

        if (Physics.Raycast(originPoint, destinationPoint, out raycastHit, castLength, interactableLayer))
        { currentObject = raycastHit.collider.gameObject; }

        else currentObject = null;
    }


    private void SetVectorsForRay(float distanceFromCamera)
    {
        originPoint = CameraManager.instance.mainCameraObject.transform.position;
        destinationPoint = CameraManager.instance.mainCameraObject.transform.forward;

        if (CameraManager.instance.secondaryCameraActive)
        {
            Vector3 mouseToNearWorldPosition = new Vector3(inputManager.mousePosition.x, inputManager.mousePosition.y, CameraManager.instance.mainCamera.nearClipPlane);
            Vector3 mouseToFarWorldPosition = new Vector3(inputManager.mousePosition.x, inputManager.mousePosition.y, CameraManager.instance.mainCamera.farClipPlane);

            originPoint = CameraManager.instance.mainCamera.ScreenToWorldPoint(mouseToNearWorldPosition);
            destinationPoint = CameraManager.instance.mainCamera.ScreenToWorldPoint(mouseToFarWorldPosition);
        }
    }


    private void CheckIfGrounded()
    {
        float checkRadius = 0.1f;
        playerLocomotion.isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius, groundLayer);
    }


    private void CheckForStep()
    {
        float castRadius = .35f;
        float castLength = 1.25f;
        float liftPadding = 0.2f;
        float lerpAmount = 0.01f;

        if (Physics.SphereCast(stepCheck.position, castRadius, Vector3.down, out slopeHit, castLength, groundLayer))
        {
            if (slopeHit.normal == Vector3.up)
            {
                playerLocomotion.onSlope = false;
                return;
            }

            playerLocomotion.onSlope = true;

            Vector3 liftedPoint = new Vector3(slopeHit.point.x, slopeHit.point.y + liftPadding, slopeHit.point.z);
            transform.position = Vector3.Lerp(transform.position, liftedPoint, lerpAmount);
        }
    }
}
