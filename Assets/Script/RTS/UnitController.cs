using UnityEngine;

// Bắt buộc có Rigidbody2D và Collider2D để chọn và di chuyển
[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class UnitController : MonoBehaviour, Controllable
{
    [Header("Chuyển động")]
    [SerializeField] float movementSpeed = 3.0f;
    Rigidbody2D rb;
    Vector2 targetPosition;
    bool moving;

    [Header("Hiệu ứng chọn")]
    [SerializeField] GameObject highlightVisual; // 🌟 Gán trong prefab

    public Vector3 Position => transform.position;

    bool isSelected;
    public bool IsSelected
    {
        get => isSelected;
        set
        {
            isSelected = value;

            // 🔦 Bật/tắt highlight khi được chọn
            if (highlightVisual != null)
                highlightVisual.SetActive(isSelected);
        }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        // ✅ Đảm bảo highlight tắt ban đầu
        if (highlightVisual != null)
            highlightVisual.SetActive(false);
    }

    void Update()
    {
        if (moving)
        {
            Vector2 current = rb.position;
            Vector2 direction = targetPosition - current;

            if (direction.sqrMagnitude < 0.01f)
            {
                moving = false;
                rb.linearVelocity = Vector2.zero;
            }
            else
            {
                Vector2 velocity = direction.normalized * movementSpeed;
                rb.linearVelocity = velocity;

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
                rb.MoveRotation(angle);
            }
        }
    }

    public void SetTarget(Vector3 destination)
    {
        targetPosition = destination;
        moving = true;
    }
}
