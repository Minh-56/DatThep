using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinLoseHandler : MonoBehaviour
{
    public GameObject resultPanel;
    public TextMeshProUGUI resultText;
    public GameObject[] stars;

    private int totalEnemies;
    private int totalAllies;
    private int alliesAlive;
    private int alliesAliveExcludingMedic;
    private int alliesCountExcludingMedic;

    void Start()
    {
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

        GameObject[] allies = GameObject.FindGameObjectsWithTag("Ally");
        totalAllies = allies.Length;
        alliesAlive = totalAllies;

        alliesCountExcludingMedic = 0;
        foreach (GameObject ally in allies)
        {
            BasicUnitInfo info = ally.GetComponent<BasicUnitInfo>();
            // QuanY là đơn vị Medic
            if (info != null && info.kind != UnitKind.QuanY)
            {
                alliesCountExcludingMedic++;
            }
        }
        alliesAliveExcludingMedic = alliesCountExcludingMedic;

        resultPanel.SetActive(false);
        foreach (var star in stars)
        {
            star.SetActive(false);
        }
    }

    public void OnEnemyDied()
    {
        totalEnemies--;
        if (totalEnemies <= 0)
        {
            HandleEndGame(true);
        }
    }

    public void OnAllyDied(GameObject ally)
    {
        alliesAlive--;
        BasicUnitInfo info = ally.GetComponent<BasicUnitInfo>();
        if (info != null && info.kind != UnitKind.QuanY)
        {
            alliesAliveExcludingMedic--;
            if (alliesAliveExcludingMedic <= 0)
            {
                HandleEndGame(false);
            }
        }
    }

    public void OnTunnelDetected()
    {
        HandleEndGame(false);
    }

    public void HandleEndGame(bool isWin)
    {
        int starsEarned = 0;
        if (isWin)
        {
            float surviveRate = alliesCountExcludingMedic > 0 ?
                (float)alliesAliveExcludingMedic / alliesCountExcludingMedic : 0f;
            if (surviveRate >= 0.8f) starsEarned = 3;
            else if (surviveRate >= 0.5f) starsEarned = 2;
            else if (surviveRate >= 0.1f) starsEarned = 1;
            else starsEarned = 0;
        }

        resultPanel.SetActive(true);
        resultText.text = isWin ? "Chiến Thắng" : "Thất Bại";

        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].SetActive(i < starsEarned);
        }

        if (isWin && SceneManager.GetActiveScene().buildIndex == 5)
        {
            Debug.Log("Hoàn thành toàn bộ 5 màn chơi!");
        }
    }

    public void OnReplayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnNextLevelButton()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
    }
}
