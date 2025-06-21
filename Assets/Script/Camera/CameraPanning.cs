using UnityEngine;

public class CameraPanning : MonoBehaviour
{
    //Thiết lập di chuyển camera
    [SerializeField] float panSpeed = 10f;
    [SerializeField] float edgeSize = 15f;

    //Zoom camera
    [SerializeField] float zoomStep = 2f;
    [SerializeField] float zoomMin = 5f;
    [SerializeField] float zoomMax = 15f;

    //Giới hạn vùng di chuyển camera
    [SerializeField] Vector2 limitMin;
    [SerializeField] Vector2 limitMax;

    Camera cam;
    Vector3 dragOrigin;
    bool dragging = false;
    Transform targetToFollow;

    void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        //bám theo đơn vị đang theo giỏi
        if (targetToFollow != null)
        {
            Vector3 target = targetToFollow.position;
            target.z = transform.position.z;
            transform.position = Vector3.Lerp(transform.position, target, 0.15f);
            return;
        }

        HandleEdgeMove();
        HandleMouseDrag();
        HandleZoom();
    }

    //Di chuyển camera khi chuột đến mép màn hình
    void HandleEdgeMove()
    {
        Vector3 pos = transform.position;
        Vector2 mouse = Input.mousePosition;

        if (mouse.x < edgeSize) pos.x -= panSpeed * Time.deltaTime;
        if (mouse.x > Screen.width - edgeSize) pos.x += panSpeed * Time.deltaTime;
        if (mouse.y < edgeSize) pos.y -= panSpeed * Time.deltaTime;
        if (mouse.y > Screen.height - edgeSize) pos.y += panSpeed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, limitMin.x, limitMax.x);
        pos.y = Mathf.Clamp(pos.y, limitMin.y, limitMax.y);

        transform.position = pos;
    }

    //Kéo chuột giữa để di chuyển camera
    void HandleMouseDrag()
    {
        if (Input.GetMouseButtonDown(2))
        {
            dragOrigin = Input.mousePosition;
            dragging = true;
        }
        if (Input.GetMouseButtonUp(2)) dragging = false;

        if (dragging)
        {
            Vector3 delta = cam.ScreenToViewportPoint(dragOrigin - Input.mousePosition);
            Vector3 move = new Vector3(delta.x * panSpeed, delta.y * panSpeed, 0);
            transform.Translate(move, Space.World);
            dragOrigin = Input.mousePosition;
        }
    }

    //zoom bằng cuộn chuột
    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            float size = cam.orthographicSize - scroll * zoomStep;
            cam.orthographicSize = Mathf.Clamp(size, zoomMin, zoomMax);
        }
    }

    // camera theo dõi đối tượng cụ thể
    public void FocusOn(Transform unit)
    {
        targetToFollow = unit;
    }

    //Hủy theo dõi
    public void CancelFollow()
    {
        targetToFollow = null;
    }
}
