using UnityEngine;

public class InventorySlot
{
    public ItemData Item { get; }
    public int Quantity { get; internal set;  }

    public InventorySlot(ItemData item, int quantity)
    {
        Item = item;
        Quantity = quantity;
    }
}