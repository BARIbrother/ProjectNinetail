using UnityEngine;

public abstract class EnemyBrain: ScriptableObject
{

    protected Enemy enemy;
    protected EnemyRuntime runtime;

    public virtual void Init(Enemy e, EnemyRuntime er)
    {
        enemy = e;
        runtime = er;
    }
    public abstract void Tick();

    public abstract void WakeUp();
}
    
