using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillInventoryEntryUI : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI countText;

    private SkillData skillData;

    public void Bind(SkillData data, int count)
    {
        skillData = data;
        //if(data.icon != null) iconImage.sprite = data.icon;
        countText.text = count > 1 ? count.ToString() : "";
    }

    public SkillData GetSkillData()
    {
        return skillData;
    }
}