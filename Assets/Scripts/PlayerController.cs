using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Rigidbody rigidbody;
    private CapsuleCollider capsuleCollider;
    private Animator animator;
    //public AnimatorOverrideController overrideAnimator;

    private Character character;
    private StateMachine stateMachine;
    private States currentState;

    public bool IsGrounded
    {
        get
        {
            Vector3 bottomCenterPoint = new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y, capsuleCollider.bounds.center.z);
            //return Physics.CheckCapsule(collider.bounds.center, bottomCenterPoint, collider.bounds.size.x / 2 * 0.1f, layerMask);
            return Physics.CheckSphere(bottomCenterPoint, 0.25f, 1);
        }
    }
    public bool isGround;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        character = GetComponent<Character>();
        stateMachine = GetComponent<StateMachine>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        stateMachine.changeStateEvent += ChangeState;

        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        stateMachine.moveEvent += Move;

        //animator.runtimeAnimatorController = overrideAnimator;
    }

    private void Update()
    {
        if (!IsGrounded)
        {
            if (currentState != States.InAir)
            {
                stateMachine.ChangeState(States.InAir);
            }
        }
        else
        {
            if (currentState == States.InAir)
            {
                stateMachine.ChangeState(States.Default);
            }
        }
        isGround = IsGrounded;
    }

    public void Move(Vector2 direction)
    {
        Vector2 moveDir = direction * character.MoveSpeed;
        rigidbody.velocity = new Vector3(moveDir.x, rigidbody.velocity.y, moveDir.y);
    }

    public void Jump()
    {
        rigidbody.AddForce(Vector3.up * character.JumpPower, ForceMode.Impulse);
        Debug.Log("Jump");
    }

    public void Jerk()
    {
        Vector3 directionJerk = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
        if (directionJerk != Vector3.zero)
        {
            stateMachine.ChangeState(States.Jerk);
            rigidbody.AddForce(directionJerk * character.JerkPower, ForceMode.Impulse);
            Debug.Log("Jerk");
        }
    }
    public void ExitJerk()
    {
        //Exin in Animation
    }

    public void BeginBlock()
    {
        stateMachine.ChangeState(States.Block);
        Debug.Log("InBlock");
    }

    public void ExitBlock()
    {
        Debug.Log("ExitBlock");
        stateMachine.ChangeState(States.Default);
    }

    public void ChangeState(States _state)
    {
        currentState = _state;
        if(_state == States.Default)
        {
            SubscribeOnDefaultEvent();
        }
        if (_state == States.Block)
        {
            SubscribeOnBlockEvent();
        }
    }

    public void SubscribeOnDefaultEvent()
    {
        stateMachine.jumpEvent += Jump;
        stateMachine.jerkEvent += Jerk;
        stateMachine.blockEvent += BeginBlock;
    }

    public void SubscribeOnBlockEvent()
    {
        stateMachine.exitBlockEvent += ExitBlock;
    }
}
