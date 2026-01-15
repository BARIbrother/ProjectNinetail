using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "BlueBuff", menuName = "Scriptable Objects/SkillBuff/BlueSkillBuff")]
public class BlueSkillBuff: SkillBuff
{
    public float bd;
    public float msc;
    public override void ApplyBuff(Skill original, GameObject user)
    {
        //Debug.Log("red skillbuff applied");
        CoroutineRunner.Instance.StartCoroutine(SpeedBuff(user));
    }

    public override void RemoveBuff(Skill original, GameObject user)
    {
    }

    IEnumerator SpeedBuff(GameObject user)
    {
        PlayerState State = user.GetComponent<PlayerState>();
        State.stats.moveSpeed *= msc;
        yield return new WaitForSeconds(bd);
        State.stats.moveSpeed /= msc;
    }
}
