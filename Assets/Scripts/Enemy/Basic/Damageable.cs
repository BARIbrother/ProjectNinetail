using System.Collections;
using System;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    Enemy enemy;

    public Action onDead;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy = gameObject.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakePhysicalDamage(float amount)
    {
        enemy.runtime.currentHP -= amount;
        if(enemy.runtime.currentHP < 0) Die();
    }

    public void TakeSANDamage(float amount)
    {
        enemy.runtime.currentSAN -= amount;
        if(enemy.runtime.currentSAN < 0)
        {
            enemy.runtime.currentAction = EnemyRuntime.EnemyAction.Charmed;
            StartCoroutine(WakeUpAfter());
        }
    }

    IEnumerator WakeUpAfter()
    {
        yield return new WaitForSeconds(5f);
        enemy.brain.WakeUp();
    }

    public void Die_Charmed()
    {
        var drops = DropManager.Roll(enemy.info.dropTable);
        foreach(DropResult drop in drops)
        {
            Debug.Log(drop.item.ItemName);
            enemy.inventory.AddSkill(drop.item.skilldata);
        }
        Debug.Log(gameObject.name + " died");
        Die();
    }

    public void Die()
    {
        onDead?.Invoke();
        Destroy(gameObject);
    }
}
