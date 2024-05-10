using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyhole : MonoBehaviour, IHandleCursor
{
    public CellGate cellGate;
    private PlayerInventory playerInventory;
    private int keyIndex = 0;

    private void Awake()
    {
        cellGate = FindObjectOfType<CellGate>();
        playerInventory = FindObjectOfType<PlayerInventory>();
    }

    public void OnCursorDown()
    {
        for (int i = 0; i < playerInventory.inventory.Count; i++)
        {
            if (playerInventory.inventory[i].itemIndex == keyIndex)
            {
                cellGate.gateLocked = false;
                playerInventory.inventory.RemoveAt(i);
                StartCoroutine(FindObjectOfType<UIManager>().PopupTextCoroutine("You used the Cell Key."));
                return;
            }
        }
        UIManager.instance.ShowPopupText("The cell is locked.  A keyhole is visible.");
    }

    public void OnCursorDrag() { }
    public void OnCursorUp() { }
    public void OnCursorClickAndHold() { }

}
