using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDiaDaoController : MonoBehaviour
{
    public static SceneDiaDaoController Instance;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadGround()
    {
        SceneManager.LoadScene("MAP"); // tên scene mặt đất
    }

    public void LoadGroundWithUnits(int doorIndex, List<Controllable> units)
    {
        StartCoroutine(LoadAndSpawn(doorIndex, units));
    }

    IEnumerator LoadAndSpawn(int doorIndex, List<Controllable> units)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync("MAP");
        while (!op.isDone) yield return null;

        var groundDoor = CuaDiaDao.AllDoors[doorIndex];
        foreach (var unit in units)
        {
            ((MonoBehaviour)unit).transform.position = groundDoor.transform.position;
        }
    }
}
