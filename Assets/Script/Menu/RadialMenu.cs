using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

[AddComponentMenu("Radial Menu Framework/RMF Core Script")]
public class RadialMenu : MonoBehaviour
{
    [HideInInspector] public RectTransform rt;
    public bool useLazySelection = true;
    public RectTransform selectionFollowerContainer;
    public Text textLabel;
    public List<RadialMenuElement> elements = new();
    public float globalOffset = 0f;

    [HideInInspector] public float currentAngle = 0f;
    [HideInInspector] public int index = 0;

    private float angleOffset;
    private int prevIndex = -1;
    private PointerEventData pointer;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
        pointer = new PointerEventData(EventSystem.current);

        if (rt == null)
            Debug.Log("Khong tim thay RectTransform cua menu chinh!");

        if (selectionFollowerContainer == null)
            Debug.Log("chưu gán GameObject");

        int count = elements.Count;
        if (count == 0) return;
        angleOffset = 360f / count;

        for (int i = 0; i < count; i++)
        {
            if (elements[i] == null)
            {
                Debug.Log("Phan tu thu " + i + " dang bi bo trong danh sach menu");
                continue;
            }

            elements[i].parentRM = this;
            elements[i].setAllAngles(angleOffset * i + globalOffset, angleOffset);
            elements[i].assignedIndex = i;
        }
    }

    void Update()
    {
        Vector2 cursor = Input.mousePosition;
        Vector2 center = rt.position;
        float rawAngle = Mathf.Atan2(cursor.y - center.y, cursor.x - center.x) * Mathf.Rad2Deg;
        float normAngle = NormalizeAngle(-rawAngle + 90f - globalOffset + angleOffset / 2f);
        currentAngle = normAngle;

        index = (int)(currentAngle / angleOffset);

        if (useLazySelection && index >= 0 && index < elements.Count)
        {
            if (!elements[index].active)
            {
                elements[index].highlightThisElement(pointer);

                if (prevIndex >= 0 && prevIndex < elements.Count && prevIndex != index)
                    elements[prevIndex].unHighlightThisElement(pointer);

                prevIndex = index;
            }

            if (Input.GetMouseButtonDown(0))
            {
                ExecuteEvents.Execute(elements[index].button.gameObject, pointer, ExecuteEvents.submitHandler);
            }
        }

        if (selectionFollowerContainer != null)
        {
            selectionFollowerContainer.rotation = Quaternion.Euler(0, 0, rawAngle + 270);
        }
    }

    float NormalizeAngle(float a)
    {
        while (a < 0f) a += 360f;
        while (a > 360f) a -= 360f;
        return a;
    }
}
