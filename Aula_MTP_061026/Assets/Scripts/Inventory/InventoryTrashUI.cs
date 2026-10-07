using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryTrashUI : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData data)
    {
        if (data.pointerDrag = null) return;
        var drag = data.pointerDrag.GetComponent<InventoryItemDrag>();
        if(drag != null) drag.TryDiscard(data.pointerId);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
