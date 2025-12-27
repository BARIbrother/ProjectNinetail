using UnityEngine;

public abstract class EnemyBrain: ScriptableObject
{
    public abstract void Decide();
    public abstract void Tick();
    public abstract void UpdateState();
}
    
