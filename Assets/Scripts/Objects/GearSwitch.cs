using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearSwitch : MonoBehaviour, IHandleCursor
{
    public GameObject baseGear;
    public GameObject topGear;
    public GameObject crank;
    public GameObject gate;
    private bool raisingGate;
    private int doubleSpeed;
    private float raiseAmount;
    private float dropAmount;
    private float gateHeightThreshold;
    private Vector3 fullRaise;


    private void Start()
    {
        doubleSpeed = 2;
        raiseAmount = 2f;
        dropAmount = -4f;
        gateHeightThreshold = 10f;
        fullRaise = new Vector3(0, gateHeightThreshold, 0);
    }


    private void Update()
    {
        if (gate.transform.position == Vector3.zero || raisingGate) return;
        
        ReverseGearRotation();
    }


    private void EngageGearRotation()
    {
        if (gate.transform.position == fullRaise) return;

        raisingGate = true;
        HandleGearRotation(Vector3.right, doubleSpeed);
        HandleGateMovement(raiseAmount);
    }


    private void ReverseGearRotation()
    {
        HandleGearRotation(Vector3.left, doubleSpeed);
        HandleGateMovement(dropAmount);
    }


    private void HandleGearRotation(Vector3 turnDirection, float speedMultiplier)
    {
        if (raisingGate)
        {
            baseGear.transform.Rotate(turnDirection);
            topGear.transform.Rotate(-turnDirection);
            crank.transform.Rotate(turnDirection * speedMultiplier);
        }
        else
        {
            baseGear.transform.Rotate(-turnDirection * speedMultiplier);
            topGear.transform.Rotate(turnDirection * speedMultiplier);
            crank.transform.Rotate(-turnDirection * speedMultiplier * speedMultiplier);
        }
    }


    private void ResetGearRotation()
    {
        baseGear.transform.rotation = Quaternion.Euler(Vector3.zero);
        topGear.transform.rotation = Quaternion.Euler(Vector3.zero);
        crank.transform.rotation = Quaternion.Euler(Vector3.zero);
    }


    private void HandleGateMovement(float moveAmount)
    {
        gate.transform.position += new Vector3(0, moveAmount, 0) * Time.deltaTime;

        if (gate.transform.position.y > gateHeightThreshold)
        { gate.transform.position = fullRaise; }

        if (gate.transform.position.y < 0)
        { 
            gate.transform.position = Vector3.zero;
            ResetGearRotation();
        }
    }


    public void OnCursorClickAndHold()
    {
        if (PlayerRaycast.currentObject == null)
        {
            raisingGate = false;
            return;
        }

        EngageGearRotation();
    }


    public void OnCursorUp() => raisingGate = false; 

    public void OnCursorDown() { }
    public void OnCursorDrag() { }


}
