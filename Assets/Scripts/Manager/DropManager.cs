using UnityEngine;

using System.Collections.Generic;

public static class DropManager
{
    public static List<DropResult> Roll(DropTable table)
    {
        List<DropResult> results = new();

        foreach (var entry in table.entries)
        {
            if (Random.value <= entry.probability)
            {
                int amount = Random.Range(entry.minAmount, entry.maxAmount + 1);
                results.Add(new DropResult(entry.item, amount));
            }
        }

        return results;
    }
}
