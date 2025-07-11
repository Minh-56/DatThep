using UnityEngine;

public class UnitGunInfo : MonoBehaviour
{
    public WeaponInfo gun;
    public int bulletAmount = 30;

    public WeaponInfo getGun()
    {
        return gun;
    }

    public int getBulletAmount()
    {
        return bulletAmount;
    }
}
