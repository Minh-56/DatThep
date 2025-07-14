using UnityEngine;

public class CuaDiaDaoInScene : MonoBehaviour
{
    public int DoorIndex; // số thứ tự cửa
    public MenuDiaDaoInScene Menu;

    float lastClickTime;
    const float doubleClickThreshold = 0.3f;

    void Start()
    {
        Menu.SetDoor(this);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) // chuột trái
        {
            float timeNow = Time.time;
            if (timeNow - lastClickTime < doubleClickThreshold)
            {
                SceneDiaDaoController.Instance.LoadGround(); // chuyển scene mặt đất
            }
            lastClickTime = timeNow;
        }

        if (Input.GetMouseButtonDown(1)) // chuột phải
        {
            Menu.ShowMenu(Input.mousePosition);
        }
    }
}
