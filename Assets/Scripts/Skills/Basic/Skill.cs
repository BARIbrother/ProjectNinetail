using UnityEngine;

public abstract class Skill
{
    public SkillData data;
    public SkillBuff buff;

    public SkillPassive passive;

    public string name;

    public Skill(SkillData d, SkillBuff b, SkillPassive p)
    {
        data = d;
        buff = b;
        passive = p;
    }

    public abstract void CastSkill();
    public abstract void Delete();
}
