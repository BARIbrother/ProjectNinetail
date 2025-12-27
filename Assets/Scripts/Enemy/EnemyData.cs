using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public float maxhp;
    public float currentHP;
    public float atkpower;
    public float defpower;
    public float speed;
    public float atkrange;
    public int direction = 2;

}
