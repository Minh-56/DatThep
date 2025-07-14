using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public Button btnGuns;
    public Button btnAmmo;
    public Button btnBombs;
    public GameObject scrollGuns;
    public GameObject scrollAmmo;
    public GameObject scrollBombs;

    void Start()
    {
        btnGuns.onClick.AddListener(() => ShowTab(0));
        btnAmmo.onClick.AddListener(() => ShowTab(1));
        btnBombs.onClick.AddListener(() => ShowTab(2));
        ShowTab(0); // Mặc định mở tab Súng
    }

    void ShowTab(int idx)
    {
        scrollGuns.SetActive(idx == 0);
        scrollAmmo.SetActive(idx == 1);
        scrollBombs.SetActive(idx == 2);
    }
}
