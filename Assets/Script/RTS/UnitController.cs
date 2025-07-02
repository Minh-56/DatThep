using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class UnitController : MonoBehaviour, Controllable
{
    Rigidbody2D Rb;
    Animator Anim;

    BasicUnitInfo unitInfo;  // lấy tốc độ di chuyển từ script này
    string WalkParam = "isWalking";
    List<Vector3> Path;
    int PathIndex;
    public bool IsMoving;

    public GameObject Highlight;
    public float StopDistance = 0.05f;

    UnitVision Vision;

    public Vector3 Position => transform.position;
    public bool IsSelected
    {
        get => Highlight.activeSelf;
        set { if (Highlight) Highlight.SetActive(value); }
    }

    void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Rb.gravityScale = 0;
        Rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        Anim = GetComponent<Animator>();
        Vision = GetComponent<UnitVision>();

        unitInfo = GetComponent<BasicUnitInfo>();  // Lấy thông tin từ BasicUnitInfo

        if (Highlight != null) Highlight.SetActive(false);
    }

    void Update()
    {
        if (!IsMoving || Path == null || PathIndex >= Path.Count)
        {
            Rb.linearVelocity = Vector2.zero;
            if (Anim) Anim.SetBool(WalkParam, false);
            return;
        }

        if (Vision != null && Vision.IsCrowdedNear(0.4f))
        {
            Rb.linearVelocity = Vector2.zero;
            if (Anim) Anim.SetBool(WalkParam, false);
            return;
        }

        Vector3 Target = Path[PathIndex];
        Vector2 Dir = (Target - transform.position);

        if (Dir.sqrMagnitude < StopDistance * StopDistance)
        {
            PathIndex++;
            return;
        }

        Rb.linearVelocity = Dir.normalized * unitInfo.getSpeed();  // dùng tốc độ từ BasicUnitInfo

        float Angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg - 90f;
        Rb.MoveRotation(Angle);

        if (Anim) Anim.SetBool(WalkParam, true);
    }

    public void SetTarget(Vector3 WorldPos)
    {
        var Start = GridManager.Instance.GetNodeFromWorld(transform.position);
        var End = GridManager.Instance.GetNodeFromWorld(WorldPos);

        // Kiểm tra xem điểm bắt đầu và kết thúc có phải là vật cản không
        if (!Start.Walkable || !End.Walkable)
        {
            Debug.LogWarning("Điểm bắt đầu hoặc kết thúc là vật cản. A* sẽ tìm đường đi khác...");
        }

        // Gọi A* để tìm đường đi
        var PathNodes = AStarPathfinder.FindPath(Start, End);

        // Nếu tìm thấy đường đi
        if (PathNodes != null)
        {
            // Chuyển các node thành các vị trí (WorldPos) và lưu vào danh sách Path
            Path = PathNodes.ConvertAll(n => n.WorldPos);
            Path.Add(WorldPos);  // Thêm điểm đến vào cuối đường đi
            PathIndex = 0;
            IsMoving = true;

            Debug.Log("Đã tìm được đường đi với " + Path.Count + " điểm");
        }
        else
        {
            Debug.LogWarning("Không tìm được đường đi! Tính toán lại để di chuyển gần nhất với điểm chỉ định...");

            // Tìm vị trí gần nhất không bị vật cản (di chuyển tới gần nhất với điểm chỉ định)
            Vector3 nearestPosition = GetNearestValidPosition(WorldPos);
            Path = new List<Vector3> { nearestPosition };
            IsMoving = true;
            PathIndex = 0;

            Debug.Log($"Điểm không thể tiếp cận trực tiếp. Di chuyển đến điểm gần nhất: {nearestPosition}");
        }
    }

    // Hàm để tìm điểm gần nhất không bị vật cản
    private Vector3 GetNearestValidPosition(Vector3 targetPos)
    {
        var targetNode = GridManager.Instance.GetNodeFromWorld(targetPos);

        // Nếu node này không thể đi được, di chuyển đến node gần nhất mà có thể đi được
        if (!targetNode.Walkable)
        {
            var neighbors = GridManager.Instance.GetNeighbors(targetNode);

            // Duyệt qua các node khác và tìm node gần nhất có thể đi được
            foreach (var neighbor in neighbors)
            {
                if (neighbor.Walkable)
                {
                    return neighbor.WorldPos;
                }
            }

            // Nếu không tìm thấy, quay lại vị trí hiện tại
            return transform.position;
        }

        // Nếu node này có thể đi được, trả về vị trí
        return targetPos;
    }

}
