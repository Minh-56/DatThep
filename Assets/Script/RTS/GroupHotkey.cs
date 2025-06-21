using UnityEngine;
using System.Collections.Generic;

public class GroupHotkey : MonoBehaviour
{
    [SerializeField] UnitSelection selector;
    Dictionary<int, List<Controllable>> groupMap = new();

    void Update()
    {
        for (int i = 1; i <= 9; i++)
        {
            KeyCode hotkey = KeyCode.Alpha0 + i;

            if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(hotkey))
            {
                groupMap[i] = new List<Controllable>(selector.selectedUnits);
            }
            else if (Input.GetKeyDown(hotkey) && groupMap.TryGetValue(i, out var group))
            {
                selector.selectedUnits.Clear();
                foreach (var unit in group)
                {
                    selector.selectedUnits.Add(unit);
                    unit.IsSelected = true;
                }
            }
        }
    }
}