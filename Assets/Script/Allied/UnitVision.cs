using UnityEngine;
using System.Collections.Generic;

public class UnitVision : MonoBehaviour
{
    public float Range = 6f;
    public float ViewAngle = 120f;
    public LayerMask WallMask;

    public bool DetectEnemy = true;
    public bool DetectAlly = true;
    public bool DetectOnlyIfMoving = false;

    public List<Transform> SeenEnemies = new();
    public List<Transform> SeenAllies = new();

    void Update()
    {
        Scan();
    }

    void Scan()
    {
        SeenEnemies.Clear();
        SeenAllies.Clear();

        var Hits = Physics2D.OverlapCircleAll(transform.position, Range);
        foreach (var H in Hits)
        {
            if (H.transform == transform) continue;

            Vector2 ToTarget = (H.transform.position - transform.position).normalized;
            float Angle = Vector2.Angle(transform.up, ToTarget);
            if (Angle > ViewAngle / 2f) continue;

            float Dist = Vector2.Distance(transform.position, H.transform.position);
            RaycastHit2D Ray = Physics2D.Raycast(transform.position, ToTarget, Dist, WallMask);
            if (Ray.collider != null) continue;

            bool IsMoving = true;
            if (DetectOnlyIfMoving)
            {
                var Rb = H.GetComponent<Rigidbody2D>();
                IsMoving = Rb != null && Rb.linearVelocity.magnitude > 0.05f;
            }

            if (IsMoving)
            {
                if (DetectEnemy && H.CompareTag("Enemy"))
                    SeenEnemies.Add(H.transform);
                if (DetectAlly && H.CompareTag("Ally"))
                    SeenAllies.Add(H.transform);
            }
        }
    }

    public bool IsCrowdedNear(float MinDistance)
    {
        foreach (var Ally in SeenAllies)
        {
            if (Vector2.Distance(transform.position, Ally.position) < MinDistance)
                return true;
        }

        foreach (var Enemy in SeenEnemies)
        {
            if (Vector2.Distance(transform.position, Enemy.position) < MinDistance)
                return true;
        }
        return false;
    }

}
