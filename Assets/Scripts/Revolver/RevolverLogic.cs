using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RevolverLogic : MonoBehaviour
{
    public List<SkillData> skilldatas;
    public Skill[] skills = new Skill[5];
    void Start()
    {
        
    }

    void Update()
    {
        if(Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            InsertNewSkill(skilldatas[1].CreateSkill());
        }
    }

    void InsertNewSkill(Skill s)
    {
        Skill nineth_skill = null;
        if(skills[skills.Length-1] != null)
        {
            nineth_skill = skills[skills.Length-1];
            nineth_skill.Delete();
        } 
        for(int i = skills.Length-1; i > 0; i --) 
        {
            skills[i] = skills[i-1];
        }
        skills[0] = s;
        //Debug.Log(s.data.strOnAddition);
    }

    public void revolve()
    {
        
        for(int i = 0; i < skills.Length; i ++)
        {
            //Debug.Log(skills[i]?.name);
        }

        Skill temp = skills[0];
        for(int i = 0; i < skills.Length-1; i ++)
        {
            skills[i] = skills[i+1];
        }
        skills[skills.Length-1] = temp;

    }

}
