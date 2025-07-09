using UnityEngine;

public class DiaDaoQuickMoveController : MonoBehaviour
{
    public static DiaDaoQuickMoveController Instance;
    public GameObject ProgressBarPrefab;

    void Awake()
    {
        Instance = this;
    }

    public void Move(int fromIndex, int toIndex)
    {
        var units = FindAnyObjectByType<UnitSelection>()?.GetSelected();
        if (units == null || units.Count == 0) return;

        var targetDoor = CuaDiaDao.AllDoors[toIndex];

        var barObj = Instantiate(ProgressBarPrefab, targetDoor.ProgressBarParent);
        var bar = barObj.GetComponent<ProgressBar>();
        bar.StartProgress(units.Count, () =>
        {
            foreach (var u in units)
            {
                Instantiate(((MonoBehaviour)u).gameObject, targetDoor.transform.position, Quaternion.identity);
            }
        });

        Debug.Log("Di chuyển nhanh từ cửa " + (fromIndex + 1) + " đến cửa " + (toIndex + 1));
    }
}
