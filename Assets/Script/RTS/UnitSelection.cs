using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class UnitSelection : MonoBehaviour
{
    [SerializeField] SpriteRenderer selectionSprite;

    Vector3 startWorldPos;
    readonly List<Controllable> allUnits = new();
    public List<Controllable> selectedUnits = new();

    void Start()
    {
        foreach (var unit in Object.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None))
        {
            if (unit is Controllable c)
                allUnits.Add(c);
        }

        if (selectionSprite != null)
            selectionSprite.gameObject.SetActive(false);
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (Input.GetMouseButtonDown(0))
        {
            startWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startWorldPos.z = 0f;

            if (selectionSprite != null)
                selectionSprite.gameObject.SetActive(true);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentMouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentMouseWorld.z = 0f;

            Vector3 lowerLeft = new(
                Mathf.Min(startWorldPos.x, currentMouseWorld.x),
                Mathf.Min(startWorldPos.y, currentMouseWorld.y),
                0f);

            Vector3 upperRight = new(
                Mathf.Max(startWorldPos.x, currentMouseWorld.x),
                Mathf.Max(startWorldPos.y, currentMouseWorld.y),
                0f);

            Vector3 size = upperRight - lowerLeft;
            Vector3 center = lowerLeft + size * 0.5f;

            if (selectionSprite != null)
            {
                selectionSprite.drawMode = SpriteDrawMode.Sliced;
                selectionSprite.transform.position = center;
                selectionSprite.size = size;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 endWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endWorldPos.z = 0f;

            float clickThreshold = 0.1f;
            if (Vector3.Distance(startWorldPos, endWorldPos) < clickThreshold)
            {
                TrySelectSingle(endWorldPos);
            }
            else
            {
                SelectUnits(startWorldPos, endWorldPos);
            }

            if (selectionSprite != null)
                selectionSprite.gameObject.SetActive(false);
        }
    }

    void SelectUnits(Vector3 a, Vector3 b)
    {
        ClearSelection();

        Vector3 min = Vector3.Min(a, b);
        Vector3 max = Vector3.Max(a, b);

        foreach (var unit in allUnits)
        {
            Vector3 pos = unit.Position;
            bool inside = pos.x > min.x && pos.x < max.x && pos.y > min.y && pos.y < max.y;

            unit.IsSelected = inside;
            if (inside)
                selectedUnits.Add(unit);
        }
    }

    void TrySelectSingle(Vector3 point)
    {
        RaycastHit2D hit = Physics2D.Raycast(point, Vector2.zero);
        if (hit.collider != null)
        {
            var unit = hit.collider.GetComponent<Controllable>();
            if (unit != null)
            {
                bool isShift = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

                if (isShift)
                {
                    bool alreadySelected = selectedUnits.Contains(unit);
                    unit.IsSelected = !alreadySelected;

                    if (alreadySelected)
                        selectedUnits.Remove(unit);
                    else
                        selectedUnits.Add(unit);
                }
                else
                {
                    ClearSelection();
                    selectedUnits.Add(unit);
                    unit.IsSelected = true;
                }
                return;
            }
        }

        ClearSelection();
    }

    public void ClearSelection()
    {
        foreach (var u in selectedUnits)
            u.IsSelected = false;
        selectedUnits.Clear();
    }

    public void SelectUnit(Controllable unit)
    {
        if (!selectedUnits.Contains(unit))
        {
            selectedUnits.Add(unit);
            unit.IsSelected = true;
        }
    }
}
