using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();


    public void PickUpItem(ItemOnObject item)
    {
        AddItem(item.itemData);
        Destroy(item.gameObject);
    }


    public void AddItem(InventoryItem item) => inventory.Add(item);
}
