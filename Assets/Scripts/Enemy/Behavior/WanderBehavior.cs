using UnityEngine;

public class WanderBehavior: IEnemyBehavior
{

#region external class
    Enemy enemy;
    EnemyRuntime runtime;
    EnemyBrain brain;
    GameObject player;
#endregion
    
#region wandering movement

    float waitTimer = 0f;
    float waitDuration = 1f;

    float moveTimer = 0f;
    float moveDureation = 3f;
#endregion

    public void Enter(Enemy e, EnemyRuntime r, EnemyBrain b)
    {
        enemy = e;
        runtime = r;
        brain = b;
        player = enemy.player;
        runtime.currentAction = EnemyRuntime.EnemyAction.Moving;
    }

    public void Tick()
    {
        switch(runtime.currentAction)
        {
            case EnemyRuntime.EnemyAction.Moving:
                TickMoving();
                break;
            case EnemyRuntime.EnemyAction.Idle:
                TickWaiting();
                break;
        }
    }

    public void TickMoving()
    {
        Vector3 pos = enemy.transform.position;


        enemy.transform.position = Vector3.MoveTowards(
            pos,
            player.transform.position,
            enemy.info.speed * Time.deltaTime
        );

        moveTimer += Time.deltaTime;
        if(moveTimer >= moveDureation)
        {
            waitTimer = 0f;
            runtime.currentAction = EnemyRuntime.EnemyAction.Idle;
        }
    }

    public void TickWaiting()
    {
        waitTimer += Time.deltaTime;

        if(waitTimer >= waitDuration)
        {
            runtime.currentAction = EnemyRuntime.EnemyAction.Moving;
            moveTimer = 0f;
        }
    }
}
