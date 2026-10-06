using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] string displayName;
    [SerializeField] Sprite icon;
    [SerializeField, Min(1)] int maxStack = 10;

    public string DisplayName => displayName;
    public Sprite Icon => icon;
    public int MaxStack => maxStack;

}
