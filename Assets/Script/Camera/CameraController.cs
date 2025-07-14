using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance { get; private set; }

    [SerializeField] CameraPanning panning;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject); // tránh trùng lặp
    }

    // theo dõi
    public void FollowTransform(Transform target)
    {
        if (panning != null && target != null)
            panning.FocusOn(target);
    }

    // huỷ theo dõi
    public void ReleaseFollow()
    {
        if (panning != null)
            panning.CancelFollow();
    }
}
