using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] InventorySlotUI[] views;



    private void OnEnable()
    {
        inventory.Changed += Refresh;
        Refresh();
    }
    private void OnDisable()
    {
        inventory.Changed -= Refresh;
      
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Refresh()
    {
        for (int i = 0; i < views.Length; i++)
        {
            if (i < inventory.Slots.Count) views[i].Bind(inventory.Slots[i], inventory);
            else views[i].Clear();
        }
    }

}
