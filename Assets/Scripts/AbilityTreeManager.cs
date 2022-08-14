using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityTreeManager : MonoBehaviour
{
    [SerializeField] private  UIStateMachine uiStateMachine;
    [SerializeField] private AbilitySlotTree[] slotTrees;

    [SerializeField] private GameObject abilityTreePanel;

    private void Awake()
    {
        SubscribeOnEvent();
    }
    private void OnEnablePanel()
    {
        abilityTreePanel.SetActive(true);
        uiStateMachine.ChangeStateUI(StateUI.GameMenu);
    }
    private void OnDisablePanel()
    {
        if (abilityTreePanel.activeSelf)
        {
            abilityTreePanel.SetActive(false);
            uiStateMachine.ChangeStateUI(StateUI.Default);
        }
    }
    private void ChangeUIState(StateUI stateUI)
    {

    }
    public void SubscribeOnEvent()
    {
        uiStateMachine.changeUIStateEvent += ChangeUIState;
        uiStateMachine.abilityPanelEvent += OnEnablePanel;
        uiStateMachine.exitMenuEvent += OnDisablePanel;
    }
}
