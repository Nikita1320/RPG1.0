using UnityEngine;

public class ItemSlotBase : MonoBehaviour
{
    [SerializeField] private ItemType typeTakeItem;
    private bool isEmpty = true;
    private ItemBase item;
    public ItemType TypeTakeItem => typeTakeItem;
    public bool IsEmpty{ get { return isEmpty; } protected set { isEmpty = value; } }
    public ItemBase Item{ get { return item; } protected set { item = value; } }

    public virtual void AddItem(ItemBase _item)
    {
        Item = _item;
        Item.currentSlot = this;
        IsEmpty = false;
    }
    public virtual void RemoveItem()
    {
        Item = null;
        IsEmpty = true;
    }
}
