using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    // Hàm này sẽ được gán cho nút "Chơi lại"
    public void ReplayCurrentLevel()
    {
        // Nếu có lưu trạng thái bằng GameManager, bạn có thể khôi phục tại đây
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Hàm này sẽ được gán cho nút "Chơi lại từ đầu"
    public void ReplayFromStart()
    {
        // Reset trạng thái game nếu có
        // GameManager.instance.ResetGame(); // nếu bạn đã có GameManager

        SceneManager.LoadScene("GameSceneLevel1"); // thay bằng tên scene màn đầu của bạn
    }

    // Hàm này sẽ được gán cho nút "Về sảnh"
    public void ReturnToLobby()
    {
        SceneManager.LoadScene("MainMenu"); // thay bằng tên scene MainMenu của bạn
    }
}
