using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public Button continueButton;
    public Button mainMenuButton;
    public Slider volumeSlider;

    private bool isPaused = false;

    void Start()
    {
        settingsPanel.SetActive(false);
        continueButton.onClick.AddListener(ResumeGame);

        if (mainMenuButton != null)
            mainMenuButton.onClick.AddListener(GoToMainMenu);

        if (volumeSlider != null)
        {
            volumeSlider.value = AudioListener.volume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                PauseGame();
            else
                ResumeGame();
        }
    }

    void PauseGame()
    {
        settingsPanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    void ResumeGame()
    {
        settingsPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Đổi tên scene nếu cần
    }

    void SetVolume(float value)
    {
        AudioListener.volume = value;
    }
}
