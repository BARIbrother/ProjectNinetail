using UnityEngine;

[System.Serializable]
public class DropEntry
{
    public Itemdata item;      // ScriptableObject 추천
    [Range(0f, 1f)]
    public float probability;  // 드롭 확률
    public int minAmount = 1;
    public int maxAmount = 1;
}