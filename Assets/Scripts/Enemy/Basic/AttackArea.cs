using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AttackArea : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<Collider2D> hitList = new();
    public HashSet<GameObject> hitEnemies = new();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isHitPlayer()
    {
        hitList.Clear();
        Physics2D.OverlapCollider(GetComponent<Collider2D>(), hitList);
        foreach(Collider2D c in hitList)
        {
            if(c.gameObject.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }

    public void checkHitEnemies()
    {
        hitList.Clear();
        Physics2D.OverlapCollider(GetComponent<Collider2D>(), hitList);
        foreach(Collider2D c in hitList)
        {
            if(c.gameObject.CompareTag("Enemy"))
            {
                hitEnemies.Add(c.gameObject);
            }
        }
    }

    public void damageToHitEnemy(float Pamount, float Samount)
    {
        checkHitEnemies();
        foreach(GameObject e in hitEnemies)
        {
            
            if(e != null)e.GetComponent<Damageable>().TakePhysicalDamage(Pamount);
            if(e != null)e.GetComponent<Damageable>().TakeSANDamage(Samount);
            if(e != null)Debug.Log(e.name + " took " + Pamount + "," + Samount + "damage");
        }
    }


    public void SetPosition(Vector3 center, float angle)
    {
        transform.position = center;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        Physics2D.SyncTransforms();
    }

    public void des()
    {
        Destroy(gameObject);
    }
}
