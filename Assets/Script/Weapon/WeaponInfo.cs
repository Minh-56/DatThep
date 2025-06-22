using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Info")]
public class WeaponInfo : ScriptableObject
{
    public string gunName;

    public AmmoKind ammoKind;
    public int baseDamage;
    public float fireRate;
    public int bulletsPerMag;
    public float reloadTime;

    public bool preferTank; // dùng cho vũ khí chống tank

    [TextArea]
    public string note;
}
