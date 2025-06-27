using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string mainMenuSceneName = "MainMenu";
    public string mapSceneName = "MapScene";
    public string gameOverSceneName = "GameOver";
    public string battleScenePrefix = "Battle";

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void LoadMap()
    {
        SceneManager.LoadScene(mapSceneName);
    }

    public void LoadBattle(int levelIndex)
    {
        SceneManager.LoadScene(battleScenePrefix);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }
}
