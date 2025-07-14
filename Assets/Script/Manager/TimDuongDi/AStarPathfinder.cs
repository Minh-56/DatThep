using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AStarPathfinder
{
    public static List<Node> FindPath(Node startNode, Node endNode)
    {
        var openSet = new List<Node> { startNode };
        var closedSet = new HashSet<Node>(); 
        var allPaths = new List<List<Node>>();

        // tìm đường đi khác nếu không đi được bằng đường hiện tại
        if (!startNode.Walkable || !endNode.Walkable)
        {
            Debug.Log("Điểm bắt đầu hoặc kết thúc là vật cản. Tính toán lại đường đi.");
        }

        while (openSet.Count > 0)
        {
            // Chọn node có FCost nhỏ nhất từ openSet
            Node currentNode = openSet.OrderBy(n => n.FCost).ThenBy(n => n.HCost).First();

            Debug.Log($"Checking Node: {currentNode.WorldPos}, FCost: {currentNode.FCost}, GCost: {currentNode.GCost}, HCost: {currentNode.HCost}");

            // Nếu tìm được điểm kết thúc, truy vết lại đường đi
            if (currentNode == endNode)
            {
                var path = RetracePath(startNode, endNode);
                allPaths.Add(path);  // Thêm đường đi vào danh sách có thể đi 
                openSet.Remove(currentNode);
                closedSet.Add(currentNode);
                continue; // tìm kiếm các đường đi khác
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            // Duyệt các neighbor của currentNode
            foreach (var neighbor in GridManager.Instance.GetNeighbors(currentNode))
            {
                // Nếu neighbor không thể đi được hoặc đã kiểm tra rồi, bỏ qua
                if (!neighbor.Walkable || closedSet.Contains(neighbor))
                    continue;

                int tentativeGCost = currentNode.GCost + GetDistance(currentNode, neighbor);

                // Nếu không có trong openSet hoặc tìm được đường đi ngắn hơn
                if (!openSet.Contains(neighbor) || tentativeGCost < neighbor.GCost)
                {
                    neighbor.GCost = tentativeGCost;
                    neighbor.HCost = GetDistance(neighbor, endNode);
                    neighbor.Parent = currentNode;

                    if (!openSet.Contains(neighbor))
                        openSet.Add(neighbor);
                }
            }
        }

        // Nếu không tìm được đường đi, tiếp tục tìm đường khác
        if (allPaths.Count > 0)
        {
            // Chọn đường đi có FCost thấp nhất từ tất cả các đường
            var bestPath = allPaths.OrderBy(path => path.Sum(node => node.FCost)).First(); // Đường đi có FCost thấp nhất
            return bestPath;
        }

        Debug.LogWarning("Không tìm được đường đi!");
        return null;
    }

    // Truy vết lại đường đi từ endNode đến startNode
    private static List<Node> RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.Parent;
        }

        path.Reverse();  // Đảo ngược đường đi từ cuối đến đầu
        return path;
    }

    // Tính toán khoảng cách giữa hai node
    private static int GetDistance(Node a, Node b)
    {
        int dx = Mathf.Abs(a.GridPos.x - b.GridPos.x);
        int dy = Mathf.Abs(a.GridPos.y - b.GridPos.y);
        return (dx + dy);  // Khoảng cách Manhattan
    }
}
