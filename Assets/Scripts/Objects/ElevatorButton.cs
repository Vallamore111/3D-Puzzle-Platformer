using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour, IHandleCursor
{
    private Elevator elevator;


    private void Awake() => elevator = FindObjectOfType<Elevator>();


    public void OnCursorDown()
    {
        elevator.ButtonPressed();
        elevator.SetElevatorDirection(elevator.ToggleDestination());
    }


    public void OnCursorDrag() { }
    public void OnCursorUp() { }
    public void OnCursorClickAndHold() { }
}
