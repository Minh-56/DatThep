using UnityEngine;
using System.Collections.Generic;

public class UnitVision : MonoBehaviour
{
    public float range = 6f;
    public float viewAngle = 100f;
    public string targetTag = "Enemy"; // có thể là "Enemy" hoặc "Ally" tùy mục tiêu muốn phát hiện
    public LayerMask wallMask;

    public bool detectOnlyIfMoving = false;

    public List<Transform> seen = new List<Transform>();

    void Update()
    {
        Scan();
    }

    void Scan()
    {
        seen.Clear();
        var hits = Physics2D.OverlapCircleAll(transform.position, range);

        foreach (var h in hits)
        {
            if (!h.CompareTag(targetTag)) continue;

            Vector2 toTarget = (h.transform.position - transform.position).normalized;
            float angle = Vector2.Angle(transform.up, toTarget);

            if (angle > viewAngle / 2f) continue;

            float dist = Vector2.Distance(transform.position, h.transform.position);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, toTarget, dist, wallMask);

            if (hit.collider != null) continue;

            if (!detectOnlyIfMoving)
            {
                seen.Add(h.transform);
            }
            else
            {
                var rb = h.GetComponent<Rigidbody2D>();
                if (rb != null && rb.linearVelocity.magnitude > 0.05f)
                    seen.Add(h.transform);
            }
        }
    }
}
