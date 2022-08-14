using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Rigidbody rigidbody;
    private CapsuleCollider capsuleCollider;
    private AnimatorManager animatorManager;
    //public AnimatorOverrideController overrideAnimator;
    private Character character;
    private StateMachine stateMachine;
    private States currentState;


    public bool isground = true;
    public bool IsGrounded
    {
        get
        {
            Vector3 bottomCenterPoint = new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y, capsuleCollider.bounds.center.z);
            //return Physics.CheckCapsule(collider.bounds.center, bottomCenterPoint, collider.bounds.size.x / 2 * 0.1f, layerMask);
            return Physics.CheckSphere(bottomCenterPoint, 0.15f, 1);
        }
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        character = GetComponent<Character>();
        stateMachine = GetComponent<StateMachine>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        animatorManager = GetComponent<AnimatorManager>();
        stateMachine.startStateEvent += StartState;
        stateMachine.exitStateEvent += ExitState;
    }

    private void Start()
    {
        SubscribeOnEvent();
    }

    private void Update()
    {
        if (!IsGrounded)
        {
            if (currentState != States.Disable && currentState != States.InAir)
            {
                stateMachine.ChangeState(States.InAir);
                animatorManager.Animator.SetBool("InAir", true);
            }
        }
        else
        {
            if (currentState == States.InAir)
            {
                Debug.Log("Transit in DefaultUpdate");
                stateMachine.ChangeState(States.Default);
                animatorManager.Animator.SetBool("InAir", false);
            }
        }
        isground = IsGrounded;
    }

    public void Move(Vector2 direction)
    {
        Vector2 moveDir = direction * character.MoveSpeed;
        if (direction != Vector2.zero)
        {
            rigidbody.velocity = new Vector3(moveDir.x, rigidbody.velocity.y, moveDir.y);
            animatorManager.Animator.SetBool("Run", true);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(moveDir.x, 0, moveDir.y)), 0.25f);
        }
        else
        {
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
            animatorManager.Animator.SetBool("Run", false);
        }
    }

    public void Jump()
    {
        rigidbody.AddForce(Vector3.up * character.JumpPower, ForceMode.Impulse);
        animatorManager.Animator.SetTrigger("Jump");
    }

    public void Jerk()
    {
        Vector3 directionJerk = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
        if (directionJerk != Vector3.zero)
        {
            stateMachine.ChangeState(States.Disable);
            rigidbody.AddForce(directionJerk * character.JerkPower, ForceMode.Impulse);
            Debug.Log(directionJerk);
            animatorManager.Animator.SetTrigger("Jerk");
        }
    }
    public void ExitJerk()
    {
        stateMachine.ChangeState(States.Default);
    }

    public void BeginBlock()
    {
        stateMachine.ChangeState(States.Block);
        animatorManager.Animator.SetBool("Block", true);
    }

    public void ExitBlock()
    {
        animatorManager.Animator.SetBool("Block", false);
        stateMachine.ChangeState(States.Default);
    }

    public void ExitState(States _state)
    {

    }
    public void StartState(States _state)
    {
        currentState = _state;
    }

    public void SubscribeOnEvent()
    {
        stateMachine.jumpEvent += Jump;
        stateMachine.jerkEvent += Jerk;
        stateMachine.blockEvent += BeginBlock;
        stateMachine.exitBlockEvent += ExitBlock;
        stateMachine.moveEvent += Move;
    }
}
