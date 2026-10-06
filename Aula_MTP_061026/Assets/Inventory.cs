using System;
using System.Collections.Generic;

using UnityEngine;

public class Inventory : MonoBehaviour
{

    [SerializeField, Min(1)] int capacity = 8;
    readonly List<InventorySlot> slots = new();

    public IReadOnlyList<InventorySlot> Slots => slots;
    public event Action Changed;


    public bool TryAdd(ItemData item, int amount = 1)
    {
        if (item == null || amount < 0) return false;
        var slot = slots.Find(s => s.Item == item);

        if (slot != null)
        {
            if (amount > item.MaxStack - slot.Quantity) return false;
            slot.Quantity += amount;
            
        }
        else
        {
            if (slots.Count >= capacity || amount > item.MaxStack) return false;
            slots.Add(new InventorySlot(item, amount));
        }
        Changed?.Invoke();
        return true;
       
    }

    public bool TryRemove(ItemData item, int amount)
    {
        if (item == null || amount < 0) return false;
        var slot = slots.Find(s => s.Item == item);
        if(slot == null || slot.Quantity < amount) return false;


                            
        slot.Quantity -= amount;
        if(slot.Quantity == 0) slots.Remove(slot);
        Changed?.Invoke();
        return true;

    }

}
