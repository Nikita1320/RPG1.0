using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneStateInput : UIStateBase<InputActionsUI>
{
    private InputActionsUI inputActionsUI;
    public override void Begin()
    {

    }

    public override void Exit()
    {

    }
    public override void Init(InputActionsUI _inputActionsUI)
    {
        inputActionsUI = _inputActionsUI;
    }
}
