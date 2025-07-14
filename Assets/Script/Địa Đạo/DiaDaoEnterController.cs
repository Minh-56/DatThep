using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiaDaoEnterController : MonoBehaviour
{
    public static DiaDaoEnterController Instance;
    float LastClickTime = 0f;
    const float DoubleClickThreshold = 0.3f;

    void Awake()
    {
        Instance = this;
    }

    // Hàm này gọi từ CuaDiaDao khi người chơi double click chuột trái
    public void TryEnterFromClick(CuaDiaDao door)
    {
        // Kiểm tra double click
        if (Time.time - LastClickTime < DoubleClickThreshold)
        {
            var units = FindAnyObjectByType<UnitSelection>()?.GetSelected();

            if (units == null || units.Count == 0)
            {
                Debug.Log("Không có đơn vị -> chuyển scene địa đạo");
                SceneManager.LoadScene("DiaDao");
            }
            else
            {
                Debug.Log("Có đơn vị -> thực hiện vào địa đạo");
                StartCoroutine(Sequence(units));
            }
        }

        LastClickTime = Time.time;
    }

    IEnumerator Sequence(List<Controllable> units)
    {
        yield return new WaitForSeconds(0.5f); // Chờ mở cửa

        foreach (var u in units)
        {
            Debug.Log("Đơn vị chui vào: " + u);
            yield return new WaitForSeconds(0.25f);
            Destroy(((MonoBehaviour)u).gameObject); // Xóa từng đơn vị
        }

        yield return new WaitForSeconds(0.5f); // Chờ đóng cửa

        Debug.Log("Chuyển scene địa đạo");
        SceneManager.LoadScene("DiaDao");
    }
}
