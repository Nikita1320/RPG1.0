using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private UIInputController inputsUI;
    [SerializeField] private ItemSlotBase[] slotInventoryBackpacks;
    [SerializeField] private EquipmentSlot[] slotEquipment;
    [SerializeField] private ConsumableSlot[] slotConsumables;
    [SerializeField] private WeaponSlot slotWepon;

    private void Start()
    {
        inputsUI = GetComponent<UIInputController>();
        InitSlots();
        SubscribeOnEvent();
    }
    private void OnEnablePanel()
    {
        inventoryPanel.SetActive(true);
        inputsUI.ChangeStateUI(StateUI.GameMenu);
    }
    private void OnDisablePanel()
    {
        if (inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(false);
            inputsUI.ChangeStateUI(StateUI.Default);
        }
    }
    private void ChangeUIState(StateUI stateUI)
    {
        
    }
    public void SubscribeOnEvent()
    {
        inputsUI.changeUIStateEvent += ChangeUIState;
        inputsUI.inventoryPanelEvent += OnEnablePanel;
        inputsUI.exitMenuEvent += OnDisablePanel;
    }
    private void InitSlots()
    {
        for (int i = 0; i < slotEquipment.Length; i++)
        {
            slotEquipment[i].Init(gameObject);
        }
        for (int i = 0; i < slotConsumables.Length; i++)
        {
            slotConsumables[i].Init(gameObject, i);
        }
        slotWepon.Init(gameObject);
    }
}
