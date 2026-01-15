using System.Collections;
using System.Data.Common;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class White: Skill
{
    WhiteData wdata;
    public White(SkillData d, SkillBuff b, SkillPassive p): base(d, b, p)
    {
        name = "white skill";
        wdata = data as WhiteData;
    }
    public override void CastSkill()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(
        new Vector3(
            Mouse.current.position.ReadValue().x,
            Mouse.current.position.ReadValue().y,
            -Camera.main.transform.position.z
            )
        );

        if(Vector3.Distance(mousePos, data.player.transform.position) <= wdata.AtkRange)
        {
            CoroutineRunner.Instance.StartCoroutine(WhiteSkillCoroutine(mousePos));
        }


    }

    IEnumerator WhiteSkillCoroutine(Vector3 atkPos)
    {
        yield return new WaitForSeconds(0.3f);
        float basic = data.player.GetComponent<PlayerState>().stats.atkPower;
        
        AttackArea attackArea = Object.Instantiate(data.AttackArea).GetComponent<AttackArea>();
        attackArea.SetPosition(atkPos, 0f);


        attackArea.damageToHitEnemy(basic * data.dmgCoeff, basic * data.SANdmgCoeff);

        float elapsed = 0f;
        float current_partition = 0f;
        while(elapsed < wdata.DotDuration)
        {
            elapsed += Time.deltaTime;
            current_partition += Time.deltaTime;
            if(current_partition >= wdata.DotInterval)
            {
                attackArea.damageToHitEnemy(basic * wdata.DotdmgCoeff, basic * wdata.DotSANdmgCoeff);
                current_partition = 0f;
            }
            yield return null;
        }
        attackArea.des();
    }



    public override void Delete()
    {
        Debug.Log(data.strOnDeletion);
    }
}
