using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiaDaoMenu : MonoBehaviour
{
    public GameObject Panel;
    public TextMeshProUGUI TitleText;
    public Button EnterDiaDaoButton;
    public Button QuickMoveButton;
    public DiaDaoQuickMoveUI QuickMoveUI;

    CuaDiaDao CurrentDoor;

    public void SetDoor(CuaDiaDao door)
    {
        CurrentDoor = door;

        EnterDiaDaoButton.onClick.RemoveAllListeners();
        EnterDiaDaoButton.onClick.AddListener(() => HandleEnterDiaDao());

        QuickMoveButton.onClick.RemoveAllListeners();
        QuickMoveButton.onClick.AddListener(() => QuickMoveUI.Show(CurrentDoor));
    }

    public void ShowMenu(Vector3 pos)
    {
        Panel.transform.position = pos;
        Panel.SetActive(true);

        if (TitleText != null && CurrentDoor != null)
        {
            TitleText.text = "Cửa địa đạo số " + (CurrentDoor.DoorIndex + 1);
        }
    }

    void HandleEnterDiaDao()
    {
        DiaDaoEnterController.Instance.TryEnterFromClick(CurrentDoor);
        Panel.SetActive(false);
    }
}
