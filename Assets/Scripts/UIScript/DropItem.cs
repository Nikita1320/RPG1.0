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
        Drag drag = eventData.pointerDrag.GetComponent<Drag>();
        if (drag.gameObject.TryGetComponent(out ItemBase itemBase))
        {
            if (itemSlot.Item == null)
            {
                if ((int)typeOfAcceptedItem == (int)itemBase.TypeItem || typeOfAcceptedItem == TypeOfAcceptedItem.Any)
                {
                    itemSlot.AddItem(itemBase);
                    drag.OldParent.GetComponent<ItemSlotBase>().RemoveItem();
                    itemBase.gameObject.transform.SetParent(itemSlot.transform);
                }
            }
            else
            {
                if ((int)typeOfAcceptedItem == (int)itemBase.TypeItem || (typeOfAcceptedItem == TypeOfAcceptedItem.Any && drag.OldParent.GetComponent<DropItem>().typeOfAcceptedItem == TypeOfAcceptedItem.Any))
                {
                    if (itemBase.TypeItem == ItemType.Consumable && itemSlot.Item.TypeItem == ItemType.Consumable && itemBase.GetType() == itemSlot.Item.GetType())
                    {
                        ConsumablesBase consumablesDrag = itemBase.GetComponent<ConsumablesBase>();
                        ConsumablesBase consumablesDrop = itemSlot.Item.GetComponent<ConsumablesBase>();
                        int availableSeats = consumablesDrop.MaxCount - consumablesDrop.CurrentCount;
                        if (availableSeats != 0)
                        {
                            int canAdd = consumablesDrag.CurrentCount - availableSeats;
                            if (canAdd <= 0)
                            {
                                consumablesDrop.CurrentCount = consumablesDrag.CurrentCount;
                                drag.OldParent.GetComponent<ItemSlotBase>().RemoveItem();
                                Destroy(itemBase.gameObject);
                            }
                            else
                            {
                                consumablesDrop.CurrentCount = availableSeats;
                                consumablesDrag.CurrentCount = -availableSeats;
                            }
                        }
                    }
                    else
                    {
                        ItemBase dragItem = drag.OldParent.GetComponent<ItemSlotBase>().Item;
                        ItemBase dropItem = itemSlot.Item;

                        drag.OldParent.GetComponent<ItemSlotBase>().RemoveItem();
                        drag.OldParent.GetComponent<ItemSlotBase>().AddItem(dropItem);

                        itemSlot.RemoveItem();
                        itemSlot.AddItem(dragItem);

                        itemBase.gameObject.transform.SetParent(itemSlot.transform);
                        itemBase.gameObject.transform.localPosition = Vector3.zero;

                        itemSlot.Item.gameObject.transform.SetParent(drag.OldParent.gameObject.transform);
                        itemSlot.Item.gameObject.transform.localPosition = Vector3.zero;
                    }
                }
            }
        }
    }
}
