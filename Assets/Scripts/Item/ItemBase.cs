using UnityEngine;

public enum ItemType
{
    Weapon,
    Helmet,
    Armor,
    Shoes,
    Consumable
}
public abstract class ItemBase : MonoBehaviour
{
    public string nameItem;
    public string description;
    public ItemType itemType;
    public ItemSlotBase currentSlot;
}
