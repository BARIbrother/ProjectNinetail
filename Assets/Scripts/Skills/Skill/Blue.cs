using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Blue: Skill
{
    
    BlueData bdata; 
    public Blue(SkillData d, SkillBuff b, SkillPassive p): base(d, b, p)
    {
        name = "blue skill";
        bdata = data as BlueData;
    }
    public override void CastSkill()
    {
        CoroutineRunner.Instance.StartCoroutine(BlueSkillCoroutine());   
    }

    IEnumerator BlueSkillCoroutine()
    {
        //dash
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(
        new Vector3(
            Mouse.current.position.ReadValue().x,
            Mouse.current.position.ReadValue().y,
            -Camera.main.transform.position.z
            )
        );
        Vector3 attackDir = (mousePos - data.player.transform.position).normalized;
        Vector3 targetPos = data.player.transform.position + attackDir * bdata.dashDistance;

        float elapsed = 0f;
        float duration = bdata.dashDistance/bdata.dashSpeed;

        while(elapsed < duration)
        {
            data.player.transform.position = Vector3.Lerp(
                data.player.transform.position,
                targetPos,
                elapsed / duration
            );
            elapsed += Time.deltaTime;
            yield return null;
        }

        //round attack
        AttackArea attackArea = Object.Instantiate(data.AttackArea).GetComponent<AttackArea>();
        attackArea.SetPosition(data.player.transform.position, 0f);

        attackArea.checkHitEnemies();
        
        foreach(GameObject e in attackArea.hitEnemies)
        {
            CoroutineRunner.Instance.StartCoroutine(pushEnemy(e));
        }
        attackArea.des();
        CoroutineRunner.Instance.StartCoroutine(boundPlayer());

        
    }

    IEnumerator pushEnemy(GameObject enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        e.runtime.canMove = false;
        float elapsed = 0f;
        Vector3 pushDir = (enemy.transform.position - data.player.transform.position).normalized;

        while(elapsed < bdata.roundAttackDuration)
        {
            enemy.transform.position = Vector3.Lerp(
                enemy.transform.position,
                data.player.transform.position + pushDir*bdata.pushAmount,
                elapsed / bdata.roundAttackDuration
            );
            elapsed += Time.deltaTime;
            yield return null;
        }
        e.runtime.canMove = true;
    }

    IEnumerator boundPlayer()
    {
        data.player.GetComponent<PlayerState>().stats.can_move = false;
        yield return new WaitForSeconds(bdata.roundAttackDuration);
        data.player.GetComponent<PlayerState>().stats.can_move = true;
    }




    public override void Delete()
    {
        Debug.Log(data.strOnDeletion);
    }
}
