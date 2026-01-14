using UnityEngine;

public struct DropResult
{
    public Itemdata item;
    public int amount;

    public DropResult(Itemdata item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
}