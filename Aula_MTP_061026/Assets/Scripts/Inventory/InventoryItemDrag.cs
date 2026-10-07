using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using JetBrains.Annotations;

public class InventoryItemDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] InventorySlotUI source;
    [SerializeField] RectTransform dragLayer;
    [SerializeField] Image ghostPrefab;
    Image ghost;
    Inventory inventory;
    ItemData item;

    int amount, pointerId;
    public void OnBeginDrag(PointerEventData data)
    {
        if (data.button != PointerEventData.InputButton.Left || ghost != null || source.Slot == null) return;

        inventory = source.Inventory;
        item = source.Slot.Item;
        amount = source.Slot.Quantity;
        pointerId = data.pointerId;
        ghost = Instantiate(ghostPrefab, dragLayer);
        ghost.sprite = item.Icon;
        ghost.raycastTarget = false;
        ghost.gameObject.SetActive(false);
        ghost.rectTransform.SetAsLastSibling();
        MoveGhost(data);
    }

    public void OnDrag(PointerEventData data)
    {
        if (ghost != null && data.pointerId == pointerId) MoveGhost(data);
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (data.pointerId == pointerId) CancelDrag();
    }
    void OnDisable() => CancelDrag();

    void MoveGhost(PointerEventData data)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(dragLayer, data.position, data.pressEventCamera, out Vector2 local);
        ghost.rectTransform.anchoredPosition = local;
    }
    void CancelDrag()
    {
        if (ghost != null) Destroy(ghost.gameObject);
        ghost = null;
        inventory = null;
        item = null;
        amount = 0;

        
    }
    public bool TryDiscard(int id)
    {
        if (ghost == null || id != pointerId || inventory == null || amount <= 0)
        {
            return false;
        }

        bool removed = inventory.TryRemove(item, amount);
        if(removed) amount = 0;
        return removed;
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
