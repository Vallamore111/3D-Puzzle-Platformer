using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarPuzzle : MonoBehaviour
{
    public GameObject[] fourAltars;
    public Elevator elevator;


    private void Awake() => elevator = FindObjectOfType<Elevator>();


    public void CheckIfSolved()
    {
        for (int i = 0; i < fourAltars.Length; i++)
        {
            var altarSwitch = fourAltars[i].GetComponent<AltarSwitch>();

            if (altarSwitch.activeButton == null)
                return;

            if (altarSwitch.activeButton.gameObject != altarSwitch.altarButtons[i].gameObject)
                return;
        }

        elevator.SetElevatorDirection(elevator.ToggleDestination());
        elevator.ToggleMovement();
        StartCoroutine(UIManager.instance.PopupTextCoroutine("Puzzle Solved!"));
    }

}
