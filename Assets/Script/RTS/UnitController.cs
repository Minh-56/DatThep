using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class UnitController : MonoBehaviour, Controllable
{
    [SerializeField] float movementSpeed = 3.0f;
    Rigidbody2D rb;
    Vector2 targetPosition;
    bool moving;

    public bool IsSelected { get; set; }
    public Vector3 Position => transform.position;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
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
