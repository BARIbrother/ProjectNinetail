using UnityEngine;

[CreateAssetMenu(fileName = "WhiteSkillPassive", menuName = "Scriptable Objects/SkillPassive/WhiteSkillPassive")]
public class WhiteSkillPassive :  SkillPassive
{
    public override void EnterPassive(GameObject user)
    {   
        user.GetComponent<PlayerState>().stats.basicAtkCoeff += 0.01f;
    }

    public override void ExitPsssive(GameObject user)
    {
        user.GetComponent<PlayerState>().stats.basicAtkCoeff -= 0.01f;
    }
}
