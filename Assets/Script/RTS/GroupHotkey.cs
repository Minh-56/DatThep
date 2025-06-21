using UnityEngine;
using System.Collections.Generic;

public class GroupHotkey : MonoBehaviour
{
    [SerializeField] UnitSelection selector;
    [SerializeField] GroupUIManager groupUI;
    public Transform Transform => this.transform;


    Dictionary<int, List<Controllable>> groupMap = new();
    int lastAssignedGroup = 0;

    void Update()
    {
        for (int i = 1; i <= 9; i++)
        {
            KeyCode key = KeyCode.Alpha0 + i;

            if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(key))
            {
                if (i <= lastAssignedGroup + 1)
                {
                    groupMap[i] = new List<Controllable>(selector.selectedUnits);
                    lastAssignedGroup = Mathf.Max(lastAssignedGroup, i);

                    Transform[] unitArray = groupMap[i].ConvertAll(u => ((MonoBehaviour)u).transform).ToArray();
                    groupUI.SetGroupInfo(i, unitArray);
                }
                else
                {
                    Debug.Log("Chỉ gán nhóm tăng dần.");
                }
            }
            else if (Input.GetKeyDown(key) && groupMap.TryGetValue(i, out var group))
            {
                selector.ClearSelection();
                foreach (var unit in group)
                {
                    if (unit != null)
                        selector.SelectUnit(unit);
                }
            }
        }
    }

    public void NotifyUnitKilled(Controllable unit)
    {
        foreach (var pair in groupMap)
        {
            if (pair.Value.Remove(unit))
            {
                groupUI.UpdateGroupCount(pair.Key, pair.Value.Count);
                if (pair.Value.Count == 0)
                {
                    groupMap.Remove(pair.Key);
                    groupUI.RemoveGroup(pair.Key);
                }
                break;
            }
        }
    }
}
