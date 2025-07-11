using UnityEngine;

public class CommandManager : MonoBehaviour
{
    [SerializeField] UnitSelection unitSelector;
    [SerializeField] Vector2 gridSpacing = new(0.8f, 0.8f);
    int rowLength = 3;

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && unitSelector.selectedUnits.Count > 0)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            for (int i = 0; i < unitSelector.selectedUnits.Count; i++)
            {
                int row = i / rowLength;
                int col = i % rowLength;
                Vector3 offset = new Vector3(col * gridSpacing.x, row * gridSpacing.y, 0f);
                Vector3 target = mousePos + offset;

                unitSelector.selectedUnits[i].SetTarget(target);
            }
        }
    }
}