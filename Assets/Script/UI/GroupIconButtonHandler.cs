using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GroupIconButtonHandler : MonoBehaviour
{
    public int groupID;
    public Transform[] groupUnits;

    [Header("Text UI")]
    public TextMeshProUGUI groupNameText;
    public TextMeshProUGUI unitCountText; 

    static int currentFollowedGroup = -1;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnGroupClick);
    }

    // Gán nhóm và đơn vị tương ứng
    public void SetGroup(int id, Transform[] units)
    {
        groupID = id;
        groupUnits = units;

        UpdateGroupTexts();
    }

    // Cập nhật số lượng đơn vị
    public void UpdateUnitCount(int count)
    {
        if (unitCountText != null)
            unitCountText.text = $"{count}";
    }

    // Cập nhật cả tên và số lượng
    void UpdateGroupTexts()
    {
        if (groupNameText != null)
            groupNameText.text = $"{groupID}";
        if (unitCountText != null)
            unitCountText.text = $"{groupUnits.Length}";
    }

    // Khi nhấn vào nút nhóm
    void OnGroupClick()
    {
        if (groupUnits == null || groupUnits.Length == 0)
            return;

        if (currentFollowedGroup == groupID)
        {
            CameraController.Instance.ReleaseFollow();
            currentFollowedGroup = -1;
        }
        else
        {
            CameraController.Instance.FollowTransform(groupUnits[0]);
            currentFollowedGroup = groupID;
        }
    }
}
