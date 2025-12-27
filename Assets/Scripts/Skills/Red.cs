using System.Data.Common;
using UnityEngine;

public class Red: Skill
{
    public Red(SkillData d): base(d) {}
    public override void Cast()
    {
        Debug.Log("fireball activated");
    }

    public override void Delete()
    {
        Debug.Log(data.strOnDeletion);
    }
}
