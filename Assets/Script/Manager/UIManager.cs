using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject PanelResult;
    public TMP_Text ResultText;
    public TMP_Text StarText;

    public void ShowResult(bool isWin, int starCount)
    {
        PanelResult.SetActive(true);
        ResultText.text = isWin ? "Chiến thắng!" : "Thất bại!";
        StarText.text = $"Sao đạt được: {starCount}";

    }
}