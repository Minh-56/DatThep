using UnityEngine;

public class CommandManager : MonoBehaviour
{
    [SerializeField] UnitSelection selector;
    [SerializeField] Vector2 spacing = new(0.8f, 0.8f);
    int rowMax = 3;

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && selector.selectedUnits.Count > 0)
        {
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorld.z = 0;

            for (int i = 0; i < selector.selectedUnits.Count; i++)
            {
                int row = i / rowMax;
                int col = i % rowMax;

                Vector3 offset = new Vector3(col * spacing.x, -row * spacing.y, 0);
                Vector3 realTarget = mouseWorld + offset;

                selector.selectedUnits[i].SetTarget(realTarget);
            }

            Debug.Log("Đã gửi lệnh di chuyển cho " + selector.selectedUnits.Count + " đơn vị.");
        }
    }
}
