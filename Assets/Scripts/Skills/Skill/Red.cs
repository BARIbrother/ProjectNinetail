using System.Data.Common;
using UnityEngine;

public class Red: Skill
{
    public Red(SkillData d, SkillBuff b, SkillPassive p): base(d, b, p)
    {
        name = "red skill";
    }
    public override void CastSkill()
    {
        
    }



    public override void Delete()
    {
        Debug.Log(data.strOnDeletion);
    }
}
