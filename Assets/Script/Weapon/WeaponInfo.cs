using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Info")]
public class WeaponInfo : ScriptableObject
{
    public string GunName;
    public Sprite GunImage;
    public AmmoKind AmmoKind;
    public int BaseDamage;
    public float FireRate;
    public int BulletsPerMag;
    public float ReloadTime;

    public bool PreferTank; // dùng cho vũ khí chống tank

    [TextArea]
    public string Note;
}
