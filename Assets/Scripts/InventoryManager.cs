using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private UIStateMachine uiStateMachine;
    [SerializeField] private Character character;
    [SerializeField] private SlotInventoryBackpack[] slotInventoryBackpacks;
    [SerializeField] private SlotEquipment[] slotEquipment;
    [SerializeField] private SlotConsumable[] slotConsumables;
    [SerializeField] private SlotWepon slotWepon;

    private void Start()
    {
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
            //slotEquipment.Init();
        }
        for (int i = 0; i < slotConsumables.Length; i++)
        {
            //slotConsumables.Init(i);
        }
        //slotWepon.Init();
    }
}
