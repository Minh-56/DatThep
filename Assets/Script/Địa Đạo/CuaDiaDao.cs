using UnityEngine;
using System.Collections.Generic;

public class CuaDiaDao : MonoBehaviour
{
    public int DoorIndex;
    public DiaDaoMenu Menu;
    public Transform ProgressBarParent;

    public static List<CuaDiaDao> AllDoors = new();

    void Awake()
    {
        AllDoors.Add(this);
    }

    void OnDestroy()
    {
        AllDoors.Remove(this);
    }

    void Start()
    {
        Menu.SetDoor(this);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Menu.ShowMenu(Input.mousePosition);
        }
    }
}
