using UnityEngine;

[CreateAssetMenu(fileName = "BlueData", menuName = "Scriptable Objects/Data/BlueData")]
public class BlueData: SkillData
{
    public float dashSpeed;
    public float dashDistance;

    public float roundAttackDuration;
    public float pushAmount;

    public float BuffDuration;
    public float MovementSpeedCoeff;
    public float PssiveAtkSpeedCoeff;

    public override Skill CreateSkill()
    {
        BlueSkillBuff bbuff = buff as BlueSkillBuff;
        bbuff.bd = BuffDuration;
        bbuff.msc = MovementSpeedCoeff;
        return new Blue(this, buff, passive);
    }
}
