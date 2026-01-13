using UnityEngine;

[CreateAssetMenu(fileName = "BlueData", menuName = "Scriptable Objects/Data/BlueData")]
public class BlueData: SkillData
{
    public float dashSpeed;
    public float dashDistance;

    public float roundAttackDuration;
    public float pushAmount;

    public override Skill CreateSkill()
    {
        return new Blue(this, buff, passive);
    }
}
