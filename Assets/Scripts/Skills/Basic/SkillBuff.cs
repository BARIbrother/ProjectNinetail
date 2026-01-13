using UnityEngine;

public abstract class SkillBuff : ScriptableObject
{
    public abstract void ApplyBuff(Skill original, GameObject user);
    public abstract void RemoveBuff(Skill original, GameObject user);
}
