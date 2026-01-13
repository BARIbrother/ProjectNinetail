using UnityEngine;
using System;

[CreateAssetMenu(fileName = "RedData", menuName = "Scriptable Objects/Data/RedData")]
public class RedData : SkillData
{
    public override Skill CreateSkill()
    {
        return new Red(this, buff, passive);
    }
}
