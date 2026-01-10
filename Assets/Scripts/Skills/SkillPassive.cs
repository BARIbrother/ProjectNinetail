using UnityEngine;

public abstract class SkillPassive : ScriptableObject
{
    public abstract void EnterPassive(GameObject user);
    public abstract void ExitPsssive(GameObject user);
}
