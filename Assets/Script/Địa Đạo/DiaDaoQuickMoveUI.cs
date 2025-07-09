using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class DiaDaoQuickMoveUI : MonoBehaviour
{
    public GameObject Popup;
    public Button Button1, Button2;
    public TextMeshProUGUI Label1, Label2;

    public void Show(CuaDiaDao from)
    {
        Popup.SetActive(true);
        var all = CuaDiaDao.AllDoors;

        int idx = 0;
        for (int i = 0; i < all.Count; i++)
        {
            if (i == from.DoorIndex) continue;

            var btn = (idx == 0) ? Button1 : Button2;
            var label = (idx == 0) ? Label1 : Label2;

            int toIndex = i;
            label.text = "Đến cửa " + (toIndex + 1);

            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() =>
            {
                DiaDaoQuickMoveController.Instance.Move(from.DoorIndex, toIndex);
                Popup.SetActive(false);
            });

            idx++;
        }
    }
}
