using UnityEngine;

[CreateAssetMenu(fileName = "EnemyInfo", menuName = "Scriptable Objects/EnemyInfo")]
public class EnemyInfo : ScriptableObject
{
    public float maxhp;
    public float maxSAN;
    public float atkpower;
    public float defpower;
    public float speed;
    public float atkrange;
    public float atkBeforeDelay;
    public float atkAfterDelay;
    public float atkinterval;

    public GameObject AttackArea;
    public GameObject AttackPreview;

    [SerializeField] public DropTable dropTable;

}
