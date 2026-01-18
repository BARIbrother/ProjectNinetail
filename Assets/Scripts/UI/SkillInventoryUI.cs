using UnityEngine;

public class SkillInventoryUI : MonoBehaviour
{
    [SerializeField] private SkillInventory inventory;
    [SerializeField] private Transform contentParent;
    [SerializeField] private SkillInventoryEntryUI entryPrefab;


    
    private void OnEnable()
    {
        inventory.OnInventoryChanged += Refresh;
        Refresh();
    }

    private void OnDisable()
    {
        inventory.OnInventoryChanged -= Refresh;
    }

    public void Refresh()
    {
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        foreach (var entry in inventory.Skills)
        {
            SkillInventoryEntryUI ui =
                Instantiate(entryPrefab, contentParent);

            ui.Bind(entry.skillData, entry.stack);
            Debug.Log("skill added to ui");
        }
    }

}