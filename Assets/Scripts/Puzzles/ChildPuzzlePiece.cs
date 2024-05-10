using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildPuzzlePiece : MonoBehaviour, IHandleCursor
{
    public Camera puzzleCam;
    private ChildPuzzle childPuzzle;
    private Vector3 mouseOffset;
    private Vector3 startPosition;
    private float raiseAmount;
    private InputManager inputManager;



    private void Awake()
    {
        childPuzzle = FindObjectOfType<ChildPuzzle>();
        inputManager = FindObjectOfType<InputManager>();
    }


    private Vector3 GetNewWorldPosition()
    {
        Vector3 objectScreenPos = puzzleCam.WorldToScreenPoint(transform.position);
        Vector3 newScreenPos = new Vector3(inputManager.mousePosition.x, inputManager.mousePosition.y, objectScreenPos.z);
        Vector3 newWorldPos = puzzleCam.ScreenToWorldPoint(newScreenPos);
        return newWorldPos;
    }


    public void CheckPlacement()
    {
        float threshold = .45f;
        if (Vector3.Distance(transform.localPosition, Vector3.zero) < threshold)
        { transform.localPosition = Vector3.zero; }
        else transform.position = startPosition;
    }


    public void SlowlyRaiseObject()
    {
        float increment = 0.01f;
        float maxRaise = 0.25f;
        raiseAmount += increment;

        if (raiseAmount > maxRaise)
        { raiseAmount = maxRaise; }
        
        else 
        {
            Vector3 raisedPosition = new Vector3(0, increment, 0);
            transform.position += raisedPosition;
        }

        mouseOffset = transform.position - GetNewWorldPosition();
    }


    public void OnCursorDown()
    {
        startPosition = transform.position;
        mouseOffset = transform.position - GetNewWorldPosition();
        Cursor.visible = !Cursor.visible;
    }


    public void OnCursorDrag()
    {
        Vector3 newPosition = GetNewWorldPosition() + mouseOffset;
        transform.position = newPosition;
    }


    public void OnCursorUp()
    {
        raiseAmount = 0;
        CheckPlacement();
        childPuzzle.CheckIfSolved();
        Cursor.visible = !Cursor.visible;
    }


    public void OnCursorClickAndHold() => SlowlyRaiseObject();
}









