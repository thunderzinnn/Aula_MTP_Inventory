using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] ItemData item;
    [SerializeField, Min(1)] int amount = 1;
    bool collected;

    private void OnTriggerEnter(Collider other)
    {
        if (collected) return;
        var invetory = other.GetComponentInParent<Inventory>();
        if (invetory == null || !invetory.TryAdd(item, amount)) return;

        collected = true;
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
