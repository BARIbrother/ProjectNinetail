using System.Collections;
using UnityEngine;
[CreateAssetMenu(fileName = "WhiteBuff", menuName = "Scriptable Objects/SkillBuff/WhiteSkillBuff")]
public class WhiteSkillBuff: SkillBuff
{
    public float scoeff;
    public override void ApplyBuff(Skill original, GameObject user)
    {
        if(original != null) original.data.SANdmgCoeff *= scoeff; 
    }

    public override void RemoveBuff(Skill original, GameObject user)
    {
        if(original != null) original.data.SANdmgCoeff /= scoeff;
    }

}

