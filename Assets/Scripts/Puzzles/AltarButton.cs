using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarButton : MonoBehaviour, IHandleCursor
{
    private float buttonPushAmount = -0.01f;
    private Vector3 buttonPushed;
    private AltarSwitch altarSwitch;


    private void Start()
    {
        altarSwitch = GetComponentInParent<AltarSwitch>();
        buttonPushed = new Vector3(0, buttonPushAmount, 0);
    }


    public void OnCursorDown()
    {
        altarSwitch.activeButton = gameObject;
        transform.localPosition = buttonPushed;
        altarSwitch.ToggleActiveButton();
    }

    public void OnCursorDrag() { }
    public void OnCursorUp() { }
    public void OnCursorClickAndHold() { }
}
