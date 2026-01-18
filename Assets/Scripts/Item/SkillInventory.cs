using System.Collections.Generic;
using UnityEngine;

public class SkillInventory : MonoBehaviour
{

    public System.Action OnInventoryChanged;

    [SerializeField]
    private List<InventorySkillEntry> skills = new();

    public IReadOnlyList<InventorySkillEntry> Skills => skills;

    public void AddSkill(SkillData data, int amount = 1)
    {
        InventorySkillEntry entry = FindEntry(data);

        if (entry != null)
        {
            entry.Add(amount);
        }
        else
        {
            skills.Add(new InventorySkillEntry(data, amount));
        }
        OnInventoryChanged?.Invoke();
    }

    public bool RemoveSkill(SkillData data, int amount = 1)
    {
        InventorySkillEntry entry = FindEntry(data);
        if (entry == null) return false;

        entry.Remove(amount);

        if (entry.stack <= 0)
        {
            skills.Remove(entry);
        }
        OnInventoryChanged?.Invoke();

        return true;
    }
    public bool HasSkill(SkillData data, int amount = 1)
    {
        InventorySkillEntry entry = FindEntry(data);
        return entry != null && entry.stack >= amount;
    }

    public int GetStack(SkillData data)
    {
        InventorySkillEntry entry = FindEntry(data);
        return entry?.stack ?? 0;
    }

    private InventorySkillEntry FindEntry(SkillData data)
    {
        return skills.Find(e => e.skillData == data);
    }
}