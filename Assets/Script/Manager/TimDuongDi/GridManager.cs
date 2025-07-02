using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    public int width = 32;
    public int height = 24;
    public float cellSize = 1f;
    public LayerMask ObstacleLayer; 

    public Node[,] Grid;

    void Awake()
    {
        Instance = this;
        GenerateGrid();
    }

    void GenerateGrid()
    {
        Grid = new Node[width, height];
        Vector3 origin = transform.position;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 worldPos = origin + new Vector3(x * cellSize, y * cellSize);
                bool walkable = !Physics2D.OverlapCircle(worldPos, cellSize * 0.4f, ObstacleLayer);  // Kiểm tra vật cản có tag Obstacle để tránh né

                Grid[x, y] = new Node
                {
                    GridPos = new Vector2Int(x, y),
                    WorldPos = worldPos,
                    Walkable = walkable  // Lưu thông tin vật cản
                };
            }
        }
    }




    public Node GetNodeFromWorld(Vector3 worldPos)
    {
        int x = Mathf.RoundToInt((worldPos.x - transform.position.x) / cellSize);
        int y = Mathf.RoundToInt((worldPos.y - transform.position.y) / cellSize);

        x = Mathf.Clamp(x, 0, width - 1);
        y = Mathf.Clamp(y, 0, height - 1);

        return Grid[x, y];
    }

    public Vector3 GetNearestWalkableWorldPos(Vector3 worldPos)
    {
        Node node = GetNodeFromWorld(worldPos);
        return node.WorldPos;
    }

    public Node[] GetNeighbors(Node node)
    {
        var neighbors = new System.Collections.Generic.List<Node>();
        Vector2Int[] dirs = {
            Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right,
            new Vector2Int(1, 1), new Vector2Int(-1, -1), new Vector2Int(-1, 1), new Vector2Int(1, -1)
        };

        foreach (var dir in dirs)
        {
            Vector2Int newPos = node.GridPos + dir;
            if (newPos.x >= 0 && newPos.x < width && newPos.y >= 0 && newPos.y < height)
            {
                neighbors.Add(Grid[newPos.x, newPos.y]);
            }
        }

        return neighbors.ToArray();
    }
}
