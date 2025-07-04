using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GroupUIManager : MonoBehaviour
{
    [SerializeField] Transform uiParent;
    [SerializeField] GameObject groupIconPrefab;

    // Nhóm 1 đến 9, mỗi nhóm tương ứng 1 icon
    Dictionary<int, GroupIconButtonHandler> groupHandlers = new();

    // Tạo icon hoặc cập nhật nhóm
    public void SetGroupInfo(int groupId, Transform[] unitList)
    {
        if (!groupHandlers.TryGetValue(groupId, out var handler))
        {
            GameObject icon = Instantiate(groupIconPrefab, uiParent);
            handler = icon.GetComponent<GroupIconButtonHandler>();
            groupHandlers[groupId] = handler;
        }

        handler.SetGroup(groupId, unitList);
    }

    // cập nhật số lượng khi có thay đổi
    public void UpdateGroupCount(int groupId, int unitCount)
    {
        if (groupHandlers.TryGetValue(groupId, out var handler))
        {
            handler.UpdateUnitCount(unitCount);
        }
    }

    // Gỡ bỏ icon nếu nhóm rỗng
    public void RemoveGroup(int groupId)
    {
        if (groupHandlers.TryGetValue(groupId, out var handler))
        {
            Destroy(handler.gameObject);
            groupHandlers.Remove(groupId);
        }
    }
}
