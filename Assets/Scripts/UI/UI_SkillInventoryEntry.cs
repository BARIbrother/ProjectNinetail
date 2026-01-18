using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillInventoryEntryUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI countText;

#region drag
    private Canvas canvas;
    private RectTransform rect;
    private CanvasGroup canvasGroup;
    private Transform originalParent;
    private Vector2 startPos;
#endregion

    private SkillData skillData;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

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

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(DragLayer.Instance.transform);
        startPos = rect.anchoredPosition;
        //canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(originalParent);
        rect.anchoredPosition = startPos;
        //canvasGroup.blocksRaycasts = true;
    }
}