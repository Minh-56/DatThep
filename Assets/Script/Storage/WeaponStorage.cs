using UnityEngine;
using System.Collections.Generic;

public class WeaponStorage : MonoBehaviour
{
    public List<GunSlot> GunList = new();
    public List<BulletSlot> AmmoList = new();

    public GameObject BoxGunPrefab;
    public GameObject BoxAmmoPrefab;

    public bool HasGun(WeaponInfo Gun)
    {
        var slot = GunList.Find(x => x.Gun == Gun);
        return slot != null && slot.Amount > 0;
    }
  
    public bool HasAmmo(AmmoKind Kind, int Num)
    {
        var slot = AmmoList.Find(x => x.AmmoKind == Kind);
        return slot != null && slot.Total >= Num;
    }

    public bool TakeGun(WeaponInfo gun)
    {
        var slot = GunList.Find(x => x.Gun == gun);
        if (slot != null && slot.Amount > 0)
        {
            slot.Amount--;
            return true;
        }
        return false;
    }

    public bool TakeAmmo(AmmoKind kind, int num)
    {
        var slot = AmmoList.Find(x => x.AmmoKind == kind);
        if (slot != null && slot.Total >= num)
        {
            slot.Total -= num;
            return true;
        }
        return false;
    }

    public void AddGun(WeaponInfo gun)
    {
        var slot = GunList.Find(x => x.Gun == gun);
        if (slot != null) slot.Amount++;
    }

    public void AddAmmo(AmmoKind kind, int num)
    {
        var slot = AmmoList.Find(x => x.AmmoKind == kind);
        if (slot != null) slot.Total += num;
    }
}
//lấy thông tin về súng
[System.Serializable]
public class GunSlot
{
    public WeaponInfo Gun;
    public int Amount;
}
//lấy thông tin về đạn
[System.Serializable]
public class BulletSlot
{
    public AmmoKind AmmoKind;
    public int Total;
}
