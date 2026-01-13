using UnityEngine;

public interface IEnemyBehavior
{
    public void Enter(Enemy e, EnemyRuntime r, EnemyBrain b);
    public void Tick();
}
