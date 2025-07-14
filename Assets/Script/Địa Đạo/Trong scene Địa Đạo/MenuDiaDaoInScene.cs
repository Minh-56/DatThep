using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuDiaDaoInScene : MonoBehaviour
{
    public GameObject Panel;
    public TextMeshProUGUI TitleText;
    public Button ExitToGroundBtn;

    CuaDiaDaoInScene currentDoor;

    public void SetDoor(CuaDiaDaoInScene door)
    {
        currentDoor = door;
        ExitToGroundBtn.onClick.RemoveAllListeners();
        ExitToGroundBtn.onClick.AddListener(() => HandleExit());
    }

    public void ShowMenu(Vector3 screenPos)
    {
        Panel.transform.position = screenPos;
        Panel.SetActive(true);

        if (TitleText != null && currentDoor != null)
            TitleText.text = "Cửa địa đạo số " + (currentDoor.DoorIndex + 1);
    }

    void HandleExit()
    {
        DiaDaoSceneExitController.Instance.Exit(currentDoor);
        Panel.SetActive(false);
    }
}
