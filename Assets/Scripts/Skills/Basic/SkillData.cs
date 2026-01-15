using System;
using UnityEngine;
public abstract class SkillData : ScriptableObject
{
    public SkillBuff buff;
    public SkillPassive passive;

    public GameObject AttackArea;
    public GameObject player;
    public float cooldown;

    public float dmgCoeff;
    public float SANdmgCoeff;
    public string strOnAddition;
    public string strOnDeletion;
    public abstract Skill CreateSkill();

    void OnEnable()
    {
        player = GameObject.Find("Player");
    }
}
