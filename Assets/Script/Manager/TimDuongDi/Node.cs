using UnityEngine;
public class Node
{
    public Vector2Int GridPos;  // Vị trí trên lưới (x, y)
    public Vector3 WorldPos;    // Vị trí thực tế trên map
    public bool Walkable;       // xác định xem node có thể đi được hay kh
    public int GCost;           // Chi phí từ node bắt đầu
    public int HCost;           // Chi phí ước tính đến điểm kết thúc
    public int FCost => GCost + HCost;  // Tổng chi phí (F = G + H)
    public Node Parent;         // Node cha của nó trong quá trình tìm đường
}
