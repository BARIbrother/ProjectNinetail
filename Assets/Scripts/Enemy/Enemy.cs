using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData data;
    public EnemyBrain brain;

    void Awake()
    {
        
    }
    void Start()
    {
        //initialize enemy
        data.currentHP = data.maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        brain.Tick();
    }
}
