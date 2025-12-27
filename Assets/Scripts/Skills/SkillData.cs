using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Scriptable Objects/SkillData")]
public abstract class SkillData : ScriptableObject
{
    public float cooldown;
    public string strOnAddition;
    public string strOnDeletion;
    public abstract Skill CreateSkill();
}
