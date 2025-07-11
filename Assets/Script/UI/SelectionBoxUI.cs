using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class SelectionBoxUI : MonoBehaviour
{
    private RectTransform box;

    void Awake()
    {
        box = GetComponent<RectTransform>();
        box.gameObject.SetActive(false);
    }

    public void Show(Vector2 start, Vector2 end)
    {
        Vector2 lowerLeft = new(Mathf.Min(start.x, end.x), Mathf.Min(start.y, end.y));
        Vector2 size = new(Mathf.Abs(end.x - start.x), Mathf.Abs(end.y - start.y));

        box.anchoredPosition = lowerLeft;
        box.sizeDelta = size;
        box.gameObject.SetActive(true);
    }

    public void Hide()
    {
        box.gameObject.SetActive(false);
    }
}
