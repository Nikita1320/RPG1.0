using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private float baseMoveSpeed = 5;

    private float currentMoveSpeed;

    public float MoveSpeed { get { return currentMoveSpeed; } set { currentMoveSpeed *= value; } }

    private float baseJumpPower = 5;

    private float currenJumpPower;

    public float JumpPower { get { return currenJumpPower; } set { currenJumpPower *= value; } }

    private float baseJerkPower = 2;

    private float currenJerkPower;

    public float JerkPower { get { return currenJerkPower; } set { currenJerkPower *= value; } }

    private void Awake()
    {
        currentMoveSpeed = baseMoveSpeed;
        currenJumpPower = baseJumpPower;
        currenJerkPower = baseJerkPower;
    }

}
