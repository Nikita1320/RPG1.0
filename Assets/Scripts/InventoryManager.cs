using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private UIStateMachine uiStateMachine;
    [SerializeField] private ItemSlotBase[] slotInventoryBackpacks;
    [SerializeField] private EquipmentSlot[] slotEquipment;
    [SerializeField] private ConsumableSlot[] slotConsumables;
    [SerializeField] private WeaponSlot slotWepon;

    private Character character;

    private void Start()
    {
        character = GetComponent<Character>();
        InitSlots();
    }
    private void OnEnablePanel()
    {
        inventoryPanel.SetActive(true);
        uiStateMachine.ChangeStateUI(StateUI.GameMenu);
    }
    private void OnDisablePanel()
    {
        if (inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(false);
            uiStateMachine.ChangeStateUI(StateUI.Default);
        }
    }
    private void ChangeUIState(StateUI stateUI)
    {
        
    }
    public void SubscribeOnEvent()
    {
        uiStateMachine.changeUIStateEvent += ChangeUIState;
        uiStateMachine.inventoryPanelEvent += OnEnablePanel;
        uiStateMachine.exitMenuEvent += OnDisablePanel;
    }
    private void InitSlots()
    {
        for (int i = 0; i < slotEquipment.Length; i++)
        {
            slotEquipment[i].Init(character);
        }
        for (int i = 0; i < slotConsumables.Length; i++)
        {
            slotConsumables[i].Init(character, i);
        }
        slotWepon.Init(character);
    }
}
