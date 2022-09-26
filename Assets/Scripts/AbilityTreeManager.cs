using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityTreeManager : MonoBehaviour
{
    [SerializeField] private  UIInputController inputsUI;
    [SerializeField] private AbilitySlotTree[] slotTrees;

    [SerializeField] private GameObject abilityTreePanel;

    private void Awake()
    {
        SubscribeOnEvent();
    }
    private void OnEnablePanel()
    {
        abilityTreePanel.SetActive(true);
        inputsUI.ChangeStateUI(StateUI.GameMenu);
    }
    private void OnDisablePanel()
    {
        if (abilityTreePanel.activeSelf)
        {
            abilityTreePanel.SetActive(false);
            inputsUI.ChangeStateUI(StateUI.Default);
        }
    }
    private void ChangeUIState(StateUI stateUI)
    {

    }
    public void SubscribeOnEvent()
    {
        inputsUI.changeUIStateEvent += ChangeUIState;
        inputsUI.abilityPanelEvent += OnEnablePanel;
        inputsUI.exitMenuEvent += OnDisablePanel;
    }
}
