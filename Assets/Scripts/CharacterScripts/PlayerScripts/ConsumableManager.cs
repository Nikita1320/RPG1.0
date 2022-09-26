using UnityEngine;

public class ConsumableManager : MonoBehaviour
{
    public delegate void UseConsumableEvent();
    public UseConsumableEvent useConsumableEvent;
    private ConsumablesBase[] consumables = new ConsumablesBase[2];
    private InputController inputController;
    private void Start()
    {
        inputController = GetComponent<InputController>();
        Subscribe();
    }
    public void AddConsumable(ConsumablesBase _consumable, int indexSlot)
    {
        consumables[indexSlot] = _consumable;
    }
    public void RemoveConsumable(int indexSlot)
    {
        consumables[indexSlot] = null;
    }
    public void UseConsumable(int index)
    {
        if (consumables[index])
        {
            consumables[index].Use();
            consumables[index].CurrentCount--;
            useConsumableEvent?.Invoke();
            if (consumables[index].CurrentCount <= 0)
            {
                Destroy(consumables[index].gameObject);
            }
        }
    }
    public void Subscribe()
    {
        inputController.consumableEvent += UseConsumable;
    }
}
