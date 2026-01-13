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
        Physics2D.OverlapCollider(GetComponent<Collider2D>(), hitList);
        foreach(Collider2D c in hitList)
        {
            if(c.gameObject.CompareTag("Enemy"))
            {
                Debug.Log(c.gameObject.transform.position);
                Debug.Log(gameObject.transform.position);
                hitEnemies.Add(c.gameObject);
            }
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
