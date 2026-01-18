using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_SkillEquipSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private Image iconImage;
    [SerializeField] private int slotIndex;
    
    [SerializeField] private RevolverLogic revolver;

    void Start()
    {
        
    }

    public void Refresh()
    {
        SkillData data = revolver.skills[slotIndex].data; 

        iconImage.enabled = data != null;
        //if (data != null) 
            //iconImage.sprite = data.icon; // icon later
    }

    public void OnDrop(PointerEventData eventData)
    {
        SkillInventoryEntryUI dragged =
            eventData.pointerDrag?.GetComponent<SkillInventoryEntryUI>();

        if (dragged == null) return;

        revolver.InsertSkill(dragged.GetSkillData(), slotIndex);
        Debug.Log("skill added to " + slotIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
