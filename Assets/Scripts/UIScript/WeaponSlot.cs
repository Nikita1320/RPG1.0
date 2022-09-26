using UnityEngine;

public class WeaponSlot : ItemSlotBase
{
    private GameObject character;
    public override void AddItem(ItemBase _item)
    {
        Item = _item;
        IsEmpty = false;
        character.GetComponent<PlayerCombatSystem>().NextWeapon = (WeaponBase)Item;
    }
    public override void RemoveItem()
    {
        Item = null;
        IsEmpty = true;
        character.GetComponent<PlayerCombatSystem>().NextWeapon = null;
    }
    public void Init(GameObject _character)
    {
        character = _character;
    }
}
