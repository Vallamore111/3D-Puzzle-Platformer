using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "Assets/Inventory Item")]

public class InventoryItem : ScriptableObject
{
    public int itemIndex;
    public string itemName;
    [TextArea(5, 10)] public string itemDescription;
}
