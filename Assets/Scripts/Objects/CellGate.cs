using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGate : MonoBehaviour, IHandleCursor
{
    public bool gateLocked;
    private int doorSpeed;
    private float doorStop;
    private Vector3 openGate;
    private Keyhole keyhole;


    private void Awake()
    {
        gateLocked = true;
        doorSpeed = 1;
        doorStop = -2.5f;
        openGate = new Vector3(doorStop, 0, 0);
        keyhole = FindObjectOfType<Keyhole>();
    }

    void Update() => UnlockGate();



    private void UnlockGate()
    {
        if (gateLocked) return;

        gameObject.layer = 0;
        keyhole.gameObject.layer = 0;

        if (transform.position.x > doorStop)
        { transform.position += Vector3.left * doorSpeed * Time.deltaTime; }

        else
        { transform.position = openGate; }

    }


    public void OnCursorDown() => UIManager.instance.ShowPopupText("The cell is locked.  A keyhole is visible.");
    public void OnCursorDrag() { }
    public void OnCursorUp() { }
    public void OnCursorClickAndHold() { }

}
