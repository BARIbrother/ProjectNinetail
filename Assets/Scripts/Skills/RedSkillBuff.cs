using System.Collections;
using UnityEngine;
[CreateAssetMenu(fileName = "RedBuff", menuName = "Scriptable Objects/RedSkillBuff")]
public class RedSkillBuff: SkillBuff
{

    public override void ApplyBuff(Skill original, GameObject user)
    {
        Debug.Log("red skillbuff applied");
        CoroutineRunner.Instance.StartCoroutine(SpeedBuff(user));
    }

    public override void RemoveBuff(Skill original, GameObject user)
    {
    }

    IEnumerator SpeedBuff(GameObject user)
    {
        PlayerState State = user.GetComponent<PlayerState>();
        State.stats.moveSpeed *= 1.5f;
        yield return new WaitForSeconds(3f);
        State.stats.moveSpeed /= 1.5f;
    }
}
