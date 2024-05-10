using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnObject : MonoBehaviour, IHandleCursor
{
    public InventoryItem itemData;


    public void OnCursorDown()
    {
        if (TryGetComponent<ItemOnObject>(out ItemOnObject itemHit))
        {
            UIManager.instance.ShowPopupText(itemHit.itemData.itemName);
            FindObjectOfType<PlayerInventory>().PickUpItem(itemHit);
        }
    }

    public void OnCursorDrag() { }
    public void OnCursorUp() { }
    public void OnCursorClickAndHold() { }
}
