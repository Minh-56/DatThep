using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class UnitController : MonoBehaviour, Controllable
{
    Rigidbody2D rb;
    Vector2 targetPoint;
    bool isMoving;

    public GameObject highlight; //Gán prefab highlight

    public Vector3 Position => transform.position;

    bool selected;
    public bool IsSelected
    {
        get => selected;
        set
        {
            selected = value;
            if (highlight != null)
                highlight.SetActive(selected);
        }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (highlight != null)
            highlight.SetActive(false);
    }

    void Update()
    {
        if (!isMoving) return;

        Vector2 now = rb.position;
        Vector2 dir = targetPoint - now;

        if (dir.sqrMagnitude < 0.01f)
        {
            isMoving = false;
            rb.linearVelocity = Vector2.zero;
            return;
        }

        float speed = 3f;

        var info = GetComponent<BasicUnitInfo>();
        if (info != null)
            speed = info.getSpeed(); //lấy tốc độ từ BasicUnitInfo

        Vector2 move = dir.normalized * speed;
        rb.linearVelocity = move;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        rb.MoveRotation(angle);
    }

    public void SetTarget(Vector3 dest)
    {
        targetPoint = dest;
        isMoving = true;
    }
}
