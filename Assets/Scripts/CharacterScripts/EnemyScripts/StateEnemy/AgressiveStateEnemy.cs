using UnityEngine;

public class AgressiveStateEnemy : BaseStateEnemy
{
    private BehaviorEnemyDefault behaviourEnemy;
    private EnemyController enemyController;
    private EnemyCombatSystem enemyCombatSystem;
    private Animator animator;
    public override void Entry()
    {

    }
    public override void Update()
    {
        if ((behaviourEnemy.Player.transform.position - behaviourEnemy.gameObject.transform.position).magnitude >= enemyController.DistanceAggression)
        {
            enemyController.EnemyNavMeshAgent.ResetPath();
            behaviourEnemy.ChangeState(StatesEnemy.Idle);
            animator.SetBool("Run", false);
            return;
        }
        else
        {
            if ((enemyController.OriginArea.position - behaviourEnemy.gameObject.transform.position).magnitude >= enemyController.DistanceToPursuit)
            {
                enemyController.EnemyNavMeshAgent.ResetPath();
            }
            else
            {
                animator.SetBool("Run", true);
                enemyController.Move(behaviourEnemy.Player.transform.position);
            }
        }
        if ((enemyController.gameObject.transform.position - behaviourEnemy.Player.transform.position).magnitude <= enemyCombatSystem.RangeAttack)
        {
            Debug.Log("EnemyAttack");
            enemyCombatSystem.Attack();
            behaviourEnemy.ChangeState(StatesEnemy.Attack);
        }
    }

    public override void Exit()
    {
        enemyController.EnemyNavMeshAgent.ResetPath();
    }

    public override void Init(GameObject enemy)
    {
        behaviourEnemy = enemy.GetComponent<BehaviorEnemyDefault>();
        enemyController = enemy.GetComponent<EnemyController>();
        enemyCombatSystem = enemy.GetComponent<EnemyCombatSystem>();
        animator = enemy.GetComponent<Animator>();
    }
}
