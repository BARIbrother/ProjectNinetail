using UnityEngine;

public class DashBehavior: IEnemyBehavior
{

    Enemy enemy;
    EnemyRuntime runtime;
    EnemyBrain brain;

    enum AttackState {Before, Attacking, After};
    AttackState ast;
    public float Ticktimer;
    public bool attackFinished;
    public Vector3 attackDir;
    public Vector3 attackCenter;

    AttackArea attackArea;
    AttackPreview attackPreview;

    bool alreadyHit = false;


    public void Enter(Enemy e, EnemyRuntime r, EnemyBrain b)
    {
        enemy = e;
        runtime = r;
        brain = b;
        attackFinished = false;
        ast = AttackState.Before;
        Ticktimer = 0f;
        SetTarget();
        GenerateAttackPreview();
    }

    public void Tick()
    {
        switch(ast)
        {
            case AttackState.Before:
                TickBefore();
                break;
            case AttackState.Attacking:
                TickAttack();
                break;
            case AttackState.After:
                TickAfter();
                break;
        }
    }

    void TickBefore()
    {
        Ticktimer += Time.deltaTime;
        if(Ticktimer > enemy.info.atkBeforeDelay)
        {
            Ticktimer = 0;
            ast = AttackState.Attacking;
            GenerateAttackArea();
        }
    }

    void TickAttack()
    {
        if(!alreadyHit) CheckHit();
        Vector3 pos = enemy.transform.position;


        enemy.transform.position = Vector3.MoveTowards(
            pos,
            pos + attackDir * 2f,
            Time.deltaTime * 10f
        );

        Ticktimer += Time.deltaTime;
        if(Ticktimer > 0.2f)
        {
            Ticktimer = 0;
            ast = AttackState.After;
            desAttackArea();
        }
    }

    void TickAfter()
    {
        Ticktimer += Time.deltaTime;
        if(Ticktimer > enemy.info.atkAfterDelay)
        {
            Ticktimer = 0;
            attackFinished = true;
        }
    }

    void SetTarget()
    {
        Vector3 selfPos = enemy.transform.position;
        Vector3 playerPos = enemy.player.transform.position;

        attackDir = (playerPos - selfPos).normalized;
        attackCenter = selfPos + 0.5f * 2f * attackDir;
    }

    void GenerateAttackPreview()
    {
        attackPreview = Object.Instantiate(enemy.info.AttackPreview).GetComponent<AttackPreview>();
        attackPreview.SetPosition(attackCenter,  Mathf.Atan2(attackDir.y, attackDir.x) * Mathf.Rad2Deg);
        attackPreview.StartFadeIn(enemy.info.atkBeforeDelay);
    }

    void GenerateAttackArea()
    {
        attackArea = Object.Instantiate(enemy.info.AttackArea).GetComponent<AttackArea>();
        attackArea.SetPosition(attackCenter,  Mathf.Atan2(attackDir.y, attackDir.x) * Mathf.Rad2Deg);
    }

    void CheckHit()
    {
        if(attackArea.isHitPlayer())
        {
            alreadyHit = true;
            Debug.Log("Changgwi Hit player"); // damage logic later
        }
    }

    void desAttackArea()
    {
        attackArea.des();
    }
}
