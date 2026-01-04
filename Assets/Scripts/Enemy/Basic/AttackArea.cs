using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<Collider2D> hitList = new();
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


    public void SetPosition(Vector3 center, float angle)
    {
        transform.position = center;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    public void des()
    {
        Destroy(gameObject);
    }
}
