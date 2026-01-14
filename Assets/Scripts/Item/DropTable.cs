using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Item/DropTable")]
public class DropTable : ScriptableObject
{
    public List<DropEntry> entries;
}
