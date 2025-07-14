using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DiaDaoSceneExitController : MonoBehaviour
{
    public static DiaDaoSceneExitController Instance;

    void Awake()
    {
        Instance = this;
    }

    public void Exit(CuaDiaDaoInScene door)
    {
        var selected = FindFirstObjectByType<UnitSelection>()?.selectedUnits;
        if (selected == null || selected.Count == 0)
        {
            Debug.Log("Không có đơn vị được chọn.");
            return;
        }

        StartCoroutine(SendUnitsUp(selected, door.DoorIndex));
    }

    IEnumerator SendUnitsUp(List<Controllable> units, int doorIndex)
    {
        foreach (var unit in units)
        {
            Debug.Log("Unit sẽ đi lên từ cửa: " + doorIndex);
            yield return new WaitForSeconds(0.3f);
            DontDestroyOnLoad(((MonoBehaviour)unit).gameObject);
        }

        SceneDiaDaoController.Instance.LoadGroundWithUnits(doorIndex, units);
    }
}
