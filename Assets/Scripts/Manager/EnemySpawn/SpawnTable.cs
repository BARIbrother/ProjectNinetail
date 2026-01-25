using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnTable", menuName = "Scriptable Objects/SpawnTable")]
public class SpawnTable : ScriptableObject
{
    public List<SpawnTableEntry> entries = new();
}
