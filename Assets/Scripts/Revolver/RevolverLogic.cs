using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RevolverLogic : MonoBehaviour
{
    public List<SkillData> skilldatas;
    Skill[] skills = new Skill[9];
    void Start()
    {
        
    }

    void Update()
    {
        if(Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            InsertNewSkill(skilldatas[0].CreateSkill());
        }
    }

    void InsertNewSkill(Skill s)
    {
        Skill nineth_skill = null;
        if(skills[8] != null)
        {
            nineth_skill = skills[8];
            nineth_skill.Delete();
        } 
        for(int i = 8; i > 0; i --) 
        {
            skills[i] = skills[i-1];
        }
        skills[0] = s;
        Debug.Log(s.data.strOnAddition);
    }
}
