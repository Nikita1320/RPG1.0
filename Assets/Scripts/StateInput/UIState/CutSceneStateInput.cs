using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneStateInput : UIStateBase
{
    private UIStateMachine uiStateMachine;
    public override void Begin()
    {

    }

    public override void Exit()
    {

    }
    public override void Init(UIStateMachine _uiStateMachine)
    {
        uiStateMachine = _uiStateMachine;
    }
}
