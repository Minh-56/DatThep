using UnityEngine;

public class CameraFollowToggle : MonoBehaviour
{
    [SerializeField] CameraPanning cameraMover;

    public void SetFocus(Transform target)
    {
        if (cameraMover != null && target != null)
        {
            cameraMover.FocusOn(target);
        }
    }

    public void ReleaseFocus()
    {
        if (cameraMover != null)
        {
            cameraMover.CancelFollow();
        }
    }
}