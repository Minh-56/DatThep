using UnityEngine;

public class CameraFollowToggle : MonoBehaviour
{
    [SerializeField] CameraPanning cameraMover;

    //cho camera theo dõi unit
    public void SetFocus(Transform target)
    {
        if (cameraMover != null && target != null)
        {
            cameraMover.FocusOn(target);
        }
    }

    // hủy chế độ theo dõi
    public void ReleaseFocus()
    {
        if (cameraMover != null)
        {
            cameraMover.CancelFollow();
        }
    }

    //theo dõi đơn vị đầu tiên của nhóm
    public void FocusOnGroup(Transform[] groupUnits)
    {
        if (groupUnits != null && groupUnits.Length > 0 && cameraMover != null)
        {
            cameraMover.FocusOn(groupUnits[0]);
        }
    }
}