using UnityEngine;

public abstract class Skill
{
    public SkillData data;
    public Skill(SkillData d)
    {
        this.data = d;
    }

    public abstract void Cast();
    public abstract void Delete();
}
