using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBar : MonoBehaviour
{
    public Image ProgressFill;
    public TextMeshProUGUI ProgressText;

    float Duration = 2f;
    int TotalUnits;
    int RemainingUnits;
    float Timer = 0f;

    enum Phase { Ingress, Waiting, Egress }
    Phase CurrentPhase = Phase.Ingress;

    System.Action OnFinish;

    public void StartProgress(int totalUnits, System.Action onFinish)
    {
        TotalUnits = totalUnits;
        RemainingUnits = totalUnits;
        Timer = 0f;
        CurrentPhase = Phase.Ingress;
        OnFinish = onFinish;

        ProgressFill.color = Color.yellow;
        ProgressFill.fillAmount = 0f;
        UpdateText(); // hiển thị: 0/Total
    }

    void Update()
    {
        Timer += Time.deltaTime;

        switch (CurrentPhase)
        {
            case Phase.Ingress:
                float ratioIn = Mathf.Clamp01(Timer / Duration);
                ProgressFill.fillAmount = ratioIn;
                if (ratioIn >= 1f)
                {
                    CurrentPhase = Phase.Waiting;
                    Timer = 0f;
                    UpdateText(true); // khi chuyển sang xanh: hiển thị Total/Total
                    ProgressFill.color = Color.green;
                }
                break;

            case Phase.Waiting:
                // delay 0.5s để tạo cảm giác
                if (Timer >= 0.5f)
                {
                    CurrentPhase = Phase.Egress;
                    Timer = Duration;
                }
                break;

            case Phase.Egress:
                Timer -= Time.deltaTime;
                float ratioOut = Mathf.Clamp01(Timer / Duration);
                ProgressFill.fillAmount = ratioOut;

                // tính số còn lại dựa trên ratio
                int newRemain = Mathf.CeilToInt(ratioOut * TotalUnits);
                if (newRemain != RemainingUnits)
                {
                    RemainingUnits = newRemain;
                    UpdateText(true);
                }

                if (Timer <= 0f)
                {
                    OnFinish?.Invoke();
                    Destroy(gameObject);
                }
                break;
        }
    }

    void UpdateText(bool full = false)
    {
        if (ProgressText != null)
        {
            if (!full)
                ProgressText.text = "0 / " + TotalUnits;
            else
                ProgressText.text = RemainingUnits + " / " + TotalUnits;
        }
    }
}
