using System;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Rendering;

public class OrbitalBehavior : IEnemyBehavior
{
#region external class
    Enemy enemy;
    EnemyRuntime runtime;
    EnemyBrain brain;
    Transform player;
#endregion

#region circular movement
    float desiredRadius = 5f;
    float angleVariance = 1;
    float radiusVariance = 1f;

    Vector3 currtentTarget;
    float repickTimer;

    float waitTimer = 0f;
    float waitDuration = 1f;
#endregion

    public void Enter(Enemy e, EnemyRuntime r, EnemyBrain b)
    {
        enemy = e;
        runtime = r;
        brain = b;
        player = enemy.player.transform;
        PickNewTarget();
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

    void TickMoving()
    {
        repickTimer += Time.deltaTime;
        if(ReachedTarget() || repickTimer > 2f)
        {
            runtime.currentAction = EnemyRuntime.EnemyAction.Idle;
            waitTimer = 0f;
        }
        else MoveTowards(currtentTarget);
    }

    void TickWaiting()
    {
        waitTimer += Time.deltaTime;

        if(waitTimer >= waitDuration)
        {
            PickNewTarget();
            runtime.currentAction = EnemyRuntime.EnemyAction.Moving;
        }
    }

    void PickNewTarget()
    {
        repickTimer = 0f;
        Vector3 toSelf = enemy.transform.position - player.position;
        float baseAngle = Mathf.Atan2(toSelf.y, toSelf.x);
        float angle = baseAngle + UnityEngine.Random.Range(-angleVariance/5, angleVariance);
        float radius = desiredRadius + UnityEngine.Random.Range(-radiusVariance, radiusVariance);

        currtentTarget = player.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0)*radius;
    }

    bool ReachedTarget()
    {
        if(Vector3.Distance(enemy.transform.position, currtentTarget) < 0.1f) return true;
        return false;
    }

    void MoveTowards(Vector3 Target)
    {
        Vector3 pos = enemy.transform.position;

        enemy.transform.position = Vector3.MoveTowards(
            pos,
            Target,
            enemy.info.speed * Time.deltaTime
        );
    }
}
