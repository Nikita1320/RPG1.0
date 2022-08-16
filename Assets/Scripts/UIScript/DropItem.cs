using UnityEngine;
using UnityEngine.EventSystems;

public enum TypeOfAcceptedItem
{
    Weapon,
    Helmet,
    Armor,
    Shoes,
    Consumable,
    Any
}
public class DropItem : MonoBehaviour, IDropHandler
{
    [SerializeField] private TypeOfAcceptedItem typeOfAcceptedItem;

    private ItemSlotBase itemSlot;
    private void Start()
    {
        itemSlot = GetComponent<ItemSlotBase>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent(out ItemBase itemBase))
        {
            if (itemSlot.IsEmpty)
            {
                if ((int)typeOfAcceptedItem == (int)itemBase.itemType || typeOfAcceptedItem == TypeOfAcceptedItem.Any)
                {
                    itemSlot.AddItem(itemBase);
                    itemBase.currentSlot.RemoveItem();

                    itemBase.gameObject.transform.SetParent(itemSlot.transform);
                    itemBase.gameObject.transform.localPosition = Vector3.zero;
                }
            }
            else
            {
                if ((int)typeOfAcceptedItem == (int)itemBase.itemType || (typeOfAcceptedItem == TypeOfAcceptedItem.Any && itemBase.currentSlot.GetComponent<DropItem>().typeOfAcceptedItem == TypeOfAcceptedItem.Any))
                {
                    if (itemBase.itemType == ItemType.Consumable && itemSlot.Item.itemType == ItemType.Consumable && itemBase.GetType() == itemSlot.Item.GetType())
                    {
                        AddInStuck(itemBase, itemSlot.Item);
                    }
                    else
                    {
                        itemBase.currentSlot.AddItem(itemSlot.Item);
                        itemSlot.AddItem(itemBase);

                        itemBase.gameObject.transform.SetParent(itemSlot.transform);
                        itemBase.gameObject.transform.localPosition = Vector3.zero;

                        itemSlot.Item.gameObject.transform.SetParent(itemBase.currentSlot.gameObject.transform);
                        itemSlot.Item.gameObject.transform.localPosition = Vector3.zero;
                    }
                }
            }
        }
    }
    public void AddInStuck(ItemBase itemDrag, ItemBase itemDrop)
    {
        ConsumablesBase consumablesDrag = itemDrag.GetComponent<ConsumablesBase>();
        ConsumablesBase consumablesDrop = itemDrop.GetComponent<ConsumablesBase>();
        int availableSeats = consumablesDrop.MaxCount - consumablesDrop.CurrentCount;
        if (availableSeats != 0)
        {
            int canAdd = consumablesDrag.CurrentCount - availableSeats;
            if (canAdd <= 0)
            {
                consumablesDrop.CurrentCount = consumablesDrag.CurrentCount;
                itemDrag.currentSlot.RemoveItem();
                Destroy(itemDrag.gameObject);
            }
            else
            {
                consumablesDrop.CurrentCount = availableSeats;
                consumablesDrag.CurrentCount = -availableSeats;
            }
        }
    }
}
