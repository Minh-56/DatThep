using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitInfoUI : MonoBehaviour
{
    public TMP_Text NameText, RoleText, HpText, SpeedText, GunText, AmmoText;
    public Button RemoveGunButton, RemoveAmmoButton;
    public Slider AmmoSlider;
    public GameObject InfoBox;

    WeaponStorage Kho;
    UnitGunInfo GunInfo;
    BasicUnitInfo BaseInfo;
    bool InsideStorage;

    void Start()
    {
        Kho = FindAnyObjectByType<WeaponStorage>();
        RemoveGunButton.onClick.AddListener(removeGun);
        RemoveAmmoButton.onClick.AddListener(removeAmmo);
        hideInfo();
    }

    //Gọi khi click chuột phải vào đơn vị quân ta
    public void showInfo(GameObject obj, bool isInsideKho)
    {
        InsideStorage = isInsideKho;
        BaseInfo = obj.GetComponent<BasicUnitInfo>();
        GunInfo = obj.GetComponent<UnitGunInfo>();

        //Gán thông tin cơ bản
        NameText.text = obj.name;
        RoleText.text = BaseInfo.kind.ToString();
        HpText.text = BaseInfo.getHp() + " máu";
        SpeedText.text = BaseInfo.getSpeed() + " m/s";

        //Gán thông tin vũ khí nếu có
        if (GunInfo != null && GunInfo.getGun() != null)
        {
            var g = GunInfo.getGun();
            GunText.text = g.GunName;
            AmmoText.text = GunInfo.getBulletAmount() + " viên";

            RemoveGunButton.gameObject.SetActive(true);
            RemoveAmmoButton.gameObject.SetActive(true);
            AmmoSlider.maxValue = GunInfo.getBulletAmount();
            AmmoSlider.value = GunInfo.getBulletAmount();
        }
        else
        {
            GunText.text = "--";
            AmmoText.text = "--";
            RemoveGunButton.gameObject.SetActive(false);
            RemoveAmmoButton.gameObject.SetActive(false);
        }

        InfoBox.SetActive(true);
    }

    public void hideInfo()
    {
        InfoBox.SetActive(false);
    }

    // Gỡ súng khỏi lính đang chọn, nếu trong khu vực Kho thì trả về Kho nếu không sẽ rơi ra
    void removeGun()
    {
        if (GunInfo == null || GunInfo.getGun() == null) return;

        if (InsideStorage)
        {
            Kho.AddGun(GunInfo.getGun());
        }
        else
        {
            if (Kho.BoxGunPrefab != null)
                Instantiate(Kho.BoxGunPrefab, GunInfo.transform.position, Quaternion.identity);
        }

        GunInfo.gun = null;
        Debug.Log("Da go sung");
        showInfo(GunInfo.gameObject, InsideStorage);
    }

    // Gỡ đạn
    void removeAmmo()
    {
        if (GunInfo == null || GunInfo.getBulletAmount() <= 0) return;

        int Quantity = (int)AmmoSlider.value;
        if (Quantity <= 0) return;

        if (InsideStorage)
        {
            Kho.AddAmmo(GunInfo.getGun().AmmoKind, Quantity);
        }
        else
        {
            if (Kho.BoxGunPrefab != null)
                Instantiate(Kho.BoxGunPrefab, GunInfo.transform.position, Quaternion.identity);
        }

        GunInfo.bulletAmount -= Quantity;
        Debug.Log("Da go " + Quantity + " vien dan");
        showInfo(GunInfo.gameObject, InsideStorage);
    }
    //đóng panel của phần thông tin
    public void ClosePanel()
    {
        this.gameObject.SetActive(false);
    }
}
