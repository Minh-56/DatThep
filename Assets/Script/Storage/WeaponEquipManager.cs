using UnityEngine;

// Script dung de cho nguoi choi chon don vi nhan sung
public class WeaponEquipManager : MonoBehaviour
{
    WeaponInfo ChooseGun;
    int AmmoNum;

    bool WaitToClick;

    void Update()
    {
        if (!WaitToClick) return;

        if (Input.GetMouseButtonDown(0))
        {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null)
            {
                var gunData = hit.collider.GetComponent<UnitGunInfo>();
                if (gunData != null)
                {
                    gunData.gun = ChooseGun;
                    gunData.bulletAmount = AmmoNum;

                    Debug.Log("Trang bi thanh cong cho don vi");
                    WaitToClick = false;
                }
            }
        }
    }

    public void StartEquipMode(WeaponInfo Gun, int Ammo)
    {
        ChooseGun = Gun;
        AmmoNum = Ammo;
        WaitToClick = true;
        Debug.Log("click vao don vi de tien hanh trang bi");
    }
}
