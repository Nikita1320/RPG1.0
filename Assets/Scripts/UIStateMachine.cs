using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateUI
{
    Default,
    GameMenu,
    CutScene
}
public class UIStateMachine : MonoBehaviour
{
    [SerializeField] private InputController inputController;
    private List<BaseStateInput<InputActionsUI, StateUI>> statesUI = new List<BaseStateInput<InputActionsUI, StateUI>>();
    private BaseStateInput<InputActionsUI, StateUI> currentStateUI;

    public InputActions inputs;
    private InputActionsUI inputActionsUI;

    public delegate void ChangeUIStateEvent(StateUI _stateUI);
    public ChangeUIStateEvent changeUIStateEvent;

    public delegate void InventoryPanelEvent();
    public InventoryPanelEvent inventoryPanelEvent;

    public delegate void AbilityPanelEvent();
    public AbilityPanelEvent abilityPanelEvent;

    public delegate void MainMenuPanelEvent();
    public MainMenuPanelEvent mainMenuPanelEvent;

    public delegate void ExitMenu();
    public ExitMenu exitMenuEvent;

    private void Start()
    {
        inputs = inputController.Inputs;
        inputActionsUI = new InputActionsUI();
        InitEvent();
        InitStates();
    }

    public void ChangeStateUI(StateUI nextStateUI)
    {
        if (nextStateUI == StateUI.Default)
        {
            if (currentStateUI != null)
            {
                inputController.RefreshCurrentState();
            }
        }
        else
        {
            inputs.Disable();
        }

        if (currentStateUI != null)
        {
            currentStateUI.Exit(nextStateUI);
        }
        currentStateUI = statesUI[(int)nextStateUI];
        currentStateUI.Begin();
        changeUIStateEvent(nextStateUI);
    }
    private void InitStates()
    {
        statesUI.Add(new DefaultStateUI());
        statesUI.Add(new InGameMenuState());
        for (int i = 0; i < statesUI.Count; i++)
        {
            statesUI[i].Init(inputActionsUI);
        }
        ChangeStateUI(StateUI.Default);
    }
    private void InitEvent()
    {
        inputActionsUI.UIDefaultInput.AbilityMenu.performed += context => abilityPanelEvent?.Invoke();
        inputActionsUI.UIDefaultInput.Invent.performed += context => inventoryPanelEvent?.Invoke();
        inputActionsUI.UIDefaultInput.MainMenu.performed += context => mainMenuPanelEvent?.Invoke();

        inputActionsUI.UIInGameMenuInput.ExitMenu.performed += context => exitMenuEvent?.Invoke();
    }
}
