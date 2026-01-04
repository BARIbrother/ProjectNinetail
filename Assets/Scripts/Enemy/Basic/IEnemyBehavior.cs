using UnityEngine;

public interface IEnemyBehavior
{
    void Enter(Enemy enemy, EnemyRuntime runtime, EnemyBrain brain);
    void Tick();
}
