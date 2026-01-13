using UnityEngine;
using UnityEngine.Rendering;

public class EnemyRuntime
{
    public float currentHP;
    public float currentSAN;
    public int direction;

    public bool canMove = true;

    public enum EnemyAction{Idle, Moving, AttackBefore, AttackPerforming, AttackAfter};
    public EnemyAction currentAction;
}
