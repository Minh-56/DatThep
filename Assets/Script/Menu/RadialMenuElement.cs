using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RadialMenuElement : MonoBehaviour
{
    [HideInInspector] public RectTransform rt;
    [HideInInspector] public RadialMenu parentRM;

    public Button button;
    public string label;

    [HideInInspector] public float angleMin, angleMax;
    [HideInInspector] public float angleOffset;
    [HideInInspector] public bool active = false;
    [HideInInspector] public int assignedIndex = 0;

    CanvasGroup cg;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
        cg = GetComponent<CanvasGroup>() ?? gameObject.AddComponent<CanvasGroup>();

        if (rt == null) Debug.Log("Không tìm thấy RectTransform cho Element");
        if (button == null) Debug.Log("chưa gán Button" + gameObject.name);
    }

    void Start()
    {
        rt.rotation = Quaternion.Euler(0, 0, -angleOffset);

        if (parentRM.useLazySelection)
        {
            cg.blocksRaycasts = false; // khong can hover truc tiep
        }
        else
        {
            EventTrigger trigger = button.GetComponent<EventTrigger>() ?? button.gameObject.AddComponent<EventTrigger>();
            trigger.triggers = new System.Collections.Generic.List<EventTrigger.Entry>();

            EventTrigger.Entry enter = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerEnter
            };
            enter.callback.AddListener((eventData) => { setParentMenuLabel(label); });

            EventTrigger.Entry exit = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerExit
            };
            exit.callback.AddListener((eventData) => { setParentMenuLabel(""); });

            trigger.triggers.Add(enter);
            trigger.triggers.Add(exit);
        }
    }

    public void setAllAngles(float offset, float baseOffset)
    {
        angleOffset = offset;
        angleMin = offset - baseOffset / 2f;
        angleMax = offset + baseOffset / 2f;
    }

    public void highlightThisElement(PointerEventData p)
    {
        ExecuteEvents.Execute(button.gameObject, p, ExecuteEvents.selectHandler);
        active = true;
        setParentMenuLabel(label);
    }

    public void unHighlightThisElement(PointerEventData p)
    {
        ExecuteEvents.Execute(button.gameObject, p, ExecuteEvents.deselectHandler);
        active = false;

        if (!parentRM.useLazySelection)
            setParentMenuLabel(" ");
    }

    public void setParentMenuLabel(string l)
    {
        if (parentRM.textLabel != null)
            parentRM.textLabel.text = l;
    }

    public void clickMeTest()
    {
        Debug.Log("Chi so nut: " + assignedIndex);
    }
}