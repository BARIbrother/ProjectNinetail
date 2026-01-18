[System.Serializable]
public class InventorySkillEntry
{
    public SkillData skillData;
    public int stack;

    public InventorySkillEntry(SkillData data, int amount)
    {
        skillData = data;
        stack = amount;
    }

    public void Add(int amount)
    {
        stack += amount;
    }

    public void Remove(int amount)
    {
        stack -= amount;
        if (stack < 0) stack = 0;
    }
}