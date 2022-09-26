using UnityEngine;
using UnityEngine.AI;

public class IdleStateEnemy : BaseStateEnemy
{
    private BehaviorEnemyDefault behaviourEnemy;
    private EnemyController enemyController;
    private float currentRestTime;
    private Vector3 targetPosition;
    private Animator animator;

    public override void Entry()
    {

    }

    public override void Exit()
    {
        enemyController.EnemyNavMeshAgent.ResetPath();
        currentRestTime = 0;
    }

    public override void Init(GameObject enemy)
    {
        behaviourEnemy = enemy.GetComponent<BehaviorEnemyDefault>();
        enemyController = enemy.GetComponent<EnemyController>();
        animator = enemy.GetComponent<Animator>();
    }

    public override void Update()
    {
        if ((behaviourEnemy.Player.transform.position - behaviourEnemy.gameObject.transform.position).magnitude <= enemyController.DistanceAggression)
        {
            behaviourEnemy.ChangeState(StatesEnemy.Agressive);
            return;
        }
        if (enemyController.EnemyNavMeshAgent.hasPath)
        {

        }
        else
        {
            if (currentRestTime <= 0)
            {
                if (RandomPoint(enemyController.OriginArea.position, enemyController.RangeArea, out targetPosition))
                {
                    animator.SetBool("Run", true);
                    enemyController.Move(targetPosition);
                }
                else
                {
                    return;
                }
            }
            else
            {
                animator.SetBool("Run", false);
                currentRestTime -= Time.deltaTime;
                return;
            }
            currentRestTime = enemyController.RestTime;
        }
    }
    private bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
