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
    [SerializeField] private string nameItem;
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;
    [SerializeField] private ItemType itemType;
    public string NameItem => nameItem;
    public string Description => description;
    public Sprite Icon => icon;
    public ItemType TypeItem => itemType;
}
