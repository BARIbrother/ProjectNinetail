using UnityEngine;

public class RangeHItScanBehavior: IEnemyBehavior
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

    public void Enter(Enemy e, EnemyRuntime r, EnemyBrain b)
    {
        enemy = e;
        runtime = r;
        brain = b;
        attackFinished = false;
        ast = AttackState.Before;
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
        }
    }
    void TickAttack()
    {
        GenerateAttackArea();
        CheckHit();
        ast = AttackState.After;
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
        attackCenter = selfPos + 0.5f * 6f * attackDir;
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
            Debug.Log("Hit player"); // damage logic later
        }
        attackArea.des();
    }
}
