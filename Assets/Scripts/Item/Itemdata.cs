using UnityEngine;

[CreateAssetMenu(fileName = "Itemdata", menuName = "Scriptable Objects/Item/Itemdata")]
public class Itemdata : ScriptableObject
{
    public string ItemName;
    public SkillData skilldata;
}
