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
    [SerializeField] private StateMachine stateMachine;
    private List<BaseStateInput> statesUI = new List<BaseStateInput>();
    private BaseStateInput currentStateUI;

    public InputController inputController;

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
        inputController = stateMachine.inputController;
        InitEvent();
        InitStates();
    }

    public void ChangeStateUI(StateUI stateUI)
    {
        if (stateUI == StateUI.Default)
        {
            if (currentStateUI != null)
            {
                stateMachine.RefreshCurrentState();
            }
        }
        else
        {
            inputController.Disable();
        }

        if (currentStateUI != null)
        {
            currentStateUI.Exit();
        }
        currentStateUI = statesUI[(int)stateUI];
        currentStateUI.Begin();
        changeUIStateEvent(stateUI);
    }
    private void InitStates()
    {
        statesUI.Add(new DefaultStateUI());
        statesUI.Add(new InGameMenuState());
        for (int i = 0; i < statesUI.Count; i++)
        {
            statesUI[i].Init(inputController);
        }
        ChangeStateUI(StateUI.Default);
    }
    public void InitEvent()
    {
        inputController.UIDefaultInput.AbilityMenu.performed += context => abilityPanelEvent?.Invoke();
        inputController.UIDefaultInput.Invent.performed += context => inventoryPanelEvent?.Invoke();
        inputController.UIDefaultInput.MainMenu.performed += context => mainMenuPanelEvent?.Invoke();

        inputController.UIInGameMenuInput.ExitMenu.performed += context => exitMenuEvent?.Invoke();
    }
}
