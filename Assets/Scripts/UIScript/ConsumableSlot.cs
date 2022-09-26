using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableSlot : ItemSlotBase
{
    private ConsumableManager consumableManager;
    private GameObject character;
    private int indexSlot;
    private ConsumablesBase consumableItem;
    public override void AddItem(ItemBase _item)
    {
        consumableItem = (ConsumablesBase)_item;
        Item = _item;
        IsEmpty = false;
        consumableManager.AddConsumable(consumableItem, indexSlot);
        consumableItem.ToClothe(character);
    }
    public override void RemoveItem()
    {
        Item = null;
        IsEmpty = true;
        consumableManager.RemoveConsumable(indexSlot);
        consumableItem.TakeOff();
    }
    public void Init(GameObject _character, int index)
    {
        indexSlot = index;
        character = _character;
    }
}
