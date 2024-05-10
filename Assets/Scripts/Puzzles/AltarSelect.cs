using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarSelect : MonoBehaviour, IHandleCursor
{
    private AltarSwitch altarSwitch;


    private void Awake() => altarSwitch = GetComponentInParent<AltarSwitch>();

    public void OnCursorDown() => altarSwitch.AltarClicked();


    public void OnCursorDrag() { }
    public void OnCursorUp() { }
    public void OnCursorClickAndHold() { }
}
