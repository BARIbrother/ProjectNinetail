using UnityEngine;

[CreateAssetMenu(fileName = "ChanggwiBrain", menuName = "Scriptable Objects/ChanggwiBrain")]
public class Brain_Changgwi: EnemyBrain
{

    IEnemyBehavior current;
    WanderBehavior wander;
    DashBehavior dash;
    float sinceLastAttack;

    public override void Init(Enemy e, EnemyRuntime er)
    {
        base.Init(e, er);
        wander = new WanderBehavior();
        dash = new DashBehavior();

        ChangeToWander();
    }

    public override void Tick()
    {
        current.Tick();
        sinceLastAttack += Time.deltaTime;
        if(current == wander && canAttack()) ChangeToDash();
        if(current == dash && dash.attackFinished) ChangeToWander();
    }

    public void ChangeToWander()
    {
        sinceLastAttack = 0f;
        current = wander;
        wander.Enter(enemy, runtime, this);
    }

    public void ChangeToDash()
    {
        current = dash;
        dash.Enter(enemy, runtime, this);
    }

    bool canAttack()
    {
        if(sinceLastAttack >= enemy.info.atkinterval && Vector3.Distance(enemy.player.transform.position, enemy.transform.position) < enemy.info.atkrange)
        {
            Debug.Log("player detected. changing to attack.");
            return true;
        }
        else return false;
    }
}
