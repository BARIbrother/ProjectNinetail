using UnityEngine;
using System;

[CreateAssetMenu(fileName = "WhiteData", menuName = "Scriptable Objects/Data/WhiteData")]
public class WhiteData : SkillData
{
    public float DotdmgCoeff;
    public float DotSANdmgCoeff;
    public float DotDuration;
    public float DotInterval;
    public float AtkRange;


    public float S_dmgCoeff;
    public float P_addCoeff;    
    public override Skill CreateSkill()
    {
        WhiteSkillBuff wbuff = buff as WhiteSkillBuff;
        wbuff.scoeff = S_dmgCoeff;
        return new White(this, buff, passive);
    }
}
