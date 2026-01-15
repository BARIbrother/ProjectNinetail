using UnityEngine;

[CreateAssetMenu(fileName = "GeuSeunSaeBrain", menuName = "Scriptable Objects/GeuSeunSaeBrain")]
public class GeuSeunSaeBrain : EnemyBrain
{
    IEnemyBehavior current;
    OrbitalBehavior orbit;
    RangeHItScanBehavior attack;
    float sinceLastAttack;

    public override void Init(Enemy e, EnemyRuntime er)
    {
        base.Init(e, er);
        orbit = new OrbitalBehavior();
        attack = new RangeHItScanBehavior();

        orbit.Enter(enemy, runtime, this);
        current = orbit;

        sinceLastAttack = 0f;
    }

    public override void Tick()
    {
        current.Tick();
        sinceLastAttack += Time.deltaTime;
        if(current == orbit && canAttack()) ChangeToAttack();
        if(current == attack && attack.attackFinished) ChangeToOrbit();
    }

    public override void WakeUp()
    {
        ChangeToOrbit();
        runtime.currentSAN = enemy.info.maxSAN;
        runtime.currentAction = EnemyRuntime.EnemyAction.Idle;
    }

    public void ChangeToOrbit()
    {
        sinceLastAttack = 0f;
        current = orbit;
        orbit.Enter(enemy, runtime, this);
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

    public void ChangeToAttack()
    {
        current = attack;
        attack.Enter(enemy, runtime, this);
    }

}
