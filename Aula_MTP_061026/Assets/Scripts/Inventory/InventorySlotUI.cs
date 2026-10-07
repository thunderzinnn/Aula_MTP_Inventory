using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TMP_Text label;

    public InventorySlot Slot {  get; private set; }
    public Inventory Inventory {  get; private set; }



    public void Bind(InventorySlot slot, Inventory owner)
    {
        Slot = slot;
        Inventory = owner;
        icon.sprite = slot.Item.Icon;
        icon.enabled = slot.Item.Icon != null;
        label.text = slot.Item.DisplayName + " x" + slot.Quantity;
}
    public void Clear()
    {
        Slot = null;
        Inventory = null;
        icon.enabled = false;
        label.text = "Vazio";
    }


    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
