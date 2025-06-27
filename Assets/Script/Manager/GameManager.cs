using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int currentLevelIndex;
    public int initialUnits = 10;
    public int currentUnits;
    public int enemyCount;
    public SaveProgressManager saveProgressManager;
    public LevelData[] levelsData;
    public WeaponStorage weaponStorage;

    const int totalLevels = 5;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        saveProgressManager = new SaveProgressManager();
        saveProgressManager.LoadProgress();
    }

    public void StartLevel(int levelIndex)
    {
        currentLevelIndex = levelIndex;
        currentUnits = initialUnits;
        enemyCount = levelsData[levelIndex].enemyCount;
        SceneController sc = FindFirstObjectByType<SceneController>();
        if (sc != null)
            sc.LoadBattle(levelIndex);
    }

    public void OnEnemyDefeated()
    {
        enemyCount--;
        if (enemyCount <= 0)
        {
            EndLevel(true);
        }
    }

    public void OnUnitDefeated()
    {
        currentUnits--;
        if (currentUnits <= 0)
        {
            EndLevel(false);
        }
    }

    public void EndLevel(bool win)
    {
        if (win)
        {
            saveProgressManager.MarkLevelCompleted(currentLevelIndex);
            saveProgressManager.SaveProgress();
        }

        UIManager ui = FindFirstObjectByType<UIManager>();
        if (ui != null)
        {
            ui.ShowResult(win, CalculateStars());
        }
    }

    public int CalculateStars()
    {
        float ratio = (float)currentUnits / initialUnits;
        if (ratio > 0.8f) return 3;
        if (ratio > 0.5f) return 2;
        if (ratio > 0.0f) return 1;
        return 0;
    }

    public void OnNextOrRetry(bool retry)
    {
        if (retry)
            StartLevel(currentLevelIndex);
        else
        {
            int next = currentLevelIndex + 1;
            if (next < totalLevels)
                StartLevel(next);
            else
                OnGameOver();
        }
    }

    public void OnGameOver()
    {
        SceneController sc = FindAnyObjectByType<SceneController>();
        if (sc != null)
            sc.LoadGameOver();
    }
}