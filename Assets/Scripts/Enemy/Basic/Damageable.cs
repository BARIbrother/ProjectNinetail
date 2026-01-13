using UnityEngine;

public class Damageable : MonoBehaviour
{
    Enemy enemy;
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
    }

    void Die()
    {
        Debug.Log(gameObject.name + " died");
        Destroy(gameObject);
    }
}
