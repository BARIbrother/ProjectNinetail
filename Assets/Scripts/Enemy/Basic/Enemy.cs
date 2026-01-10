using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyInfo info;
    public EnemyBrain brain;
    public EnemyRuntime runtime; 

    public GameObject player;
    void Awake()
    {
        InitializeEnemy();
    }
    void Start()
    {
        
    }

    void Update()
    {
        brain.Tick();
    }

    void InitializeEnemy()
    {
        player = GameObject.Find("Player");
        runtime = new EnemyRuntime();
        brain.Init(this, runtime);
        runtime.currentHP = info.maxhp;
    }
}
