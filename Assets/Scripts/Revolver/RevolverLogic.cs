using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RevolverLogic : MonoBehaviour
{
    public List<SkillData> skilldatas;
    public Skill[] skills = new Skill[5];

    public SkillInventory inventory;
    void Start()
    {
        
    }

    void Update()
    {
        if(Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            inventory.AddSkill(skilldatas[1]);
            //InsertNewSkill(skilldatas[1], 0);
        }
        if(Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            inventory.AddSkill(skilldatas[2]);
            //InsertNewSkill(skilldatas[2], 1);
        }
        if(Keyboard.current.pKey.wasPressedThisFrame)
        {
            printNames();
        }
    }

    public void InsertSkill(SkillData d, int index)
    {
        skills[index] = d.CreateSkill();
    }

    public void revolve()
    {
        
        

        Skill temp = skills[0];
        for(int i = 0; i < skills.Length-1; i ++)
        {
            skills[i] = skills[i+1];
        }
        skills[skills.Length-1] = temp;

    }

    void printNames()
    {
        for(int i = 0; i < skills.Length; i ++)
        {
            Debug.Log(skills[i]?.name);
        }    
    }

}
