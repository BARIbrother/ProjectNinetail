using UnityEngine;
using System;

[CreateAssetMenu(fileName = "RedData", menuName = "Scriptable Objects/RedData")]
public class RedData : SkillData
{
    public override Skill CreateSkill()
    {
        return new Red(this);
    }
}
