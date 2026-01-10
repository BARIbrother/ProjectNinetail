using System;
using UnityEngine;
public abstract class SkillData : ScriptableObject
{
    public SkillBuff buff;
    public SkillPassive passive;
    public float cooldown;
    public string strOnAddition;
    public string strOnDeletion;
    public abstract Skill CreateSkill();
}
